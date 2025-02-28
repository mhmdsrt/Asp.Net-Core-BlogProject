using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using X.PagedList.Extensions;

namespace BlogProject.Controllers
{
	/*
Asenkron metotlar, programın yukarıdan aşağıya doğru çalışmasını durdurmaz, işlemi başlatır ve sonuç gelene kadar diğer kodların çalışmasına izin verir.
📌 Özetle:
Senkron metotlar: İşlem tamamlanana kadar kodun ilerlemesini durdurur (bloklar).
Asenkron metotlar: İşlemi başlatır, ancak sonuç gelene kadar beklemez; programın geri kalanı çalışmaya devam eder.


Senkron: Bir restorana gittin, sipariş verdin ve yemeğin gelene kadar garson sana hizmet edemiyor.
Asenkron: Siparişi verdin, garson mutfağa söyledi ve bu sırada başka müşterilerle ilgileniyor. İşlem tamamlanınca yemeğin getiriliyor. 🍽️


Task: Asenkron bir metot, işlemin tamamlanıp tamamlanmadığını takip etmek için Task döndürür. 
Bu, çağıran tarafın await ile işlemi bekleyebilmesini sağlar.
	 */
	[AllowAnonymous]
	public class BlogController : Controller
	{
		private readonly IBlogService _blogService;
		private readonly ICategoryService _categoryService;
		private readonly ICommentService _commentService;
		private readonly IWriterService _writerService;

		public BlogController(IBlogService blogService, ICategoryService categoryService, ICommentService commentService, IWriterService writerService)
		{
			_blogService = blogService;
			_categoryService = categoryService;
			_commentService = commentService;
			_writerService = writerService;
		}
		// Index sayfası varsayılan sayfadır yani Index Action'u varsayılan Action'dur.

		
		public IActionResult Index(string searchWord,int page = 1)
		{
			if (!string.IsNullOrEmpty(searchWord))
			{
				return View(_blogService.GetBlogsWithWriterCategory().Where(x=>x.BlogContent.Contains(searchWord) | x.BlogTitle.Contains(searchWord) | x.Writer.WriterName.Contains(searchWord)).ToPagedList(page, 9));

			}
			return View(_blogService.GetBlogsWithWriterCategory().ToPagedList(page, 9));
		}
		/*
		 Razor Syntax' da @{} ile @() arasındaki fark şudur:
		 @{} birden fazla kod satırını çalıştırır ve sonuc html içerisinde gömülmez yani sadece kodları çalıştırır web sayfasına birşey yansımaz.
		 @() ifadesi tek satır kod satırını çalıştırır ve sonuc html içerisine gömülür çalışan kodların sonucu web sayfasında gözükür.
		 
		 */

		[HttpGet]
		public IActionResult BlogDetail(int id)
		{
			return View(_blogService.GetBlogByIdIncludeWriterCategory(id));
		}

		[HttpGet]
		public IActionResult InsertBlog()
		{
			List<SelectListItem> categoryList = (from c in _categoryService.GetAll()
												 select new SelectListItem
												 {
													 Text = c.CategoryName,
													 Value = c.CategoryID.ToString()

												 }).ToList();

			ViewBag.categoryDropDownList = categoryList;

			return View();
		}

		[HttpPost]
		public IActionResult InsertBlog(Blog entity) // DropList kodlarını burada da yazmamızın sebebi return view() ile dropdownlist'in bos dönmesidir.
		{
			List<SelectListItem> categoryList = (from c in _categoryService.GetAll()
												 select new SelectListItem
												 {
													 Text = c.CategoryName,
													 Value = c.CategoryID.ToString()

												 }).ToList();

			ViewBag.categoryDropDownList = categoryList;

			BlogValidator blogValidator = new BlogValidator();
			ValidationResult validationResult = blogValidator.Validate(entity);
			if (!validationResult.IsValid)
			{
				foreach (var item in validationResult.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
				return View();
			}

			entity.BlogStatus = true;
			entity.WriterID = _writerService.GetWriterIdByMail(User.Identity.Name);
			entity.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			_blogService.Insert(entity);
			return RedirectToAction("Index", "Writer");
		}

		public IActionResult DeleteBlog(int id)
		{  // Aşağıdaki yorum satırındaki işlemler Burada Controller'da yani Sunum Katmanında yapılmaz bu Servisin işidir!!!!!!!!!
			/*
			 İlişkili tablolarda veri silme işlemi için "Set null" yöntemini kullandım
			 Burada her yorumun(Comment'in) ait olduğu bir blog olduğundan dolayı bloğu silmeden önce o bloğa ait yorumların ait olduğu BlogID değerini null yapacağız.
			 */
			//var commentsToDelete = _commentService.GetCommentsByBlog(id);
			//if (commentsToDelete != null)
			//{
			//	foreach (var item in commentsToDelete)
			//	{
			//		item.BlogID = null;
			//		_commentService.Update(item);
			//	}
			//}

			_commentService.SetNullCommentWillBeDeleteBlog(id);
			_blogService.Delete(id);
			return RedirectToAction("WriterEditBlogs", "Writer");
		}


		[HttpGet]

		public IActionResult UpdateBlog(int id)
		{
			List<SelectListItem> categoryList = (from c in _categoryService.GetAll()
												 select new SelectListItem
												 {
													 Text = c.CategoryName,
													 Value = c.CategoryID.ToString()

												 }).ToList();

			ViewBag.categoryDropDownList = categoryList;
			return View(_blogService.GetById(id));
		}

		[HttpPost]

		public IActionResult UpdateBlog(Blog entity)
		{
			entity.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			entity.BlogStatus = true;
			entity.WriterID = _writerService.GetWriterIdByMail(User.Identity.Name);
			_blogService.Update(entity);
			return RedirectToAction("WriterEditBlogs", "Writer");
		}

		public IActionResult GetBlogsByCategory(int id, int page = 1)
		{
			ViewBag.CategoryName = _categoryService.GetCategoryNameById(id);
			return View(_blogService.GetAllBlogsByCategory(id).ToPagedList(page, 9));
		}
		[HttpPost]
		public IActionResult InsertCommentByBlog([FromBody] Comment entity) // [FromBody] attribute'i gelen json formatıntak veriyi c# nesnesine dönüştürür, burada Comment nesnesine dönüştürüyoryz
		{
			CommentValidator commentValidator = new CommentValidator();
			ValidationResult validationResult = commentValidator.Validate(entity);
			if (!validationResult.IsValid)
			{
				foreach (var item in validationResult.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
				return View();
			}
			entity.CommentTitle = "Default";
			entity.CommentStatus = true;
			entity.CommentCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			_commentService.Insert(entity);
			return Json(entity);
			
		}

		// entity nesnesi, HTTP isteğinin gövdesinden gelen JSON verisini temsil eder.
		// Örneğin, JSON verisi şu şekilde olabilir:
		// {
		//     "CommentUserName": "KullanıcıAdı",
		//     "CommentTitle": "Başlık",
		//     "CommentContent": "İçerik",
		//     "BlogID": 123
		// }
		// Bu JSON verisi otomatik olarak `Comment` sınıfına dönüştürülür.
	}
}
