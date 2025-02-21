using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using X.PagedList.Extensions;

namespace BlogProject.Areas.Admin.Controllers
{
	[AllowAnonymous]
	[Area("Admin")]

	public class CategoryController : Controller
	{
		private readonly ICategoryService _categoryService;
		private readonly IBlogService _blogService;
		public CategoryController(ICategoryService categoryService, IBlogService blogService)
		{
			_categoryService = categoryService;
			_blogService = blogService;
		}
		/*
		 Burada parametreye değer vererek metot kullanım şekli eğer parametre gönderilmezse
         varsayılan olarak her zaman page=1 olsun demek.
		 */
		public IActionResult Index(int page = 1) // page parametresine değer atanmazsa varsayılan olarak değeri 1' olarak ayarlanır.
		{
			return View(_categoryService.GetAll().ToPagedList(page,1)); // .ToPagedList(page,2) -> ikinci parametre her sayfada gösterilecek öğe sayısı, ilk parametre kaçıncı sayfadan başlanacağı
		}

		[HttpGet]
		public IActionResult InsertCategory()
		{
			return View();
		}

		[HttpPost]

		public IActionResult InsertCategory(Category entity)
		{
			entity.CategoryStatus = true;
			_categoryService.Insert(entity);
			return RedirectToAction("Index", "Category");
		}

		public IActionResult DeleteCategory(int id)
		{
			_blogService.SetNullBlogWillBeDeleteCategory(id);
			_categoryService.Delete(id);

			return RedirectToAction("Index", "Category");
		}
	}
}
