using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
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
	public class BlogService : GenericService<Blog>, IBlogService
	{
		private readonly IBlogRepository _blogRepository;
		public BlogService(IBlogRepository repository) : base(repository) // Eğer burada IBlogRepository değilde IGenericRepository<Blog> kullansaydık BlogRepository'ye özel metotları yani aşağıdaki metotlarını kullanamayacaktık. 
																		  // Sadece IGenericRepository<Blog> metotlarını kullabilecektik.
		{
			_blogRepository = repository;
		}

		public IEnumerable<Blog> GetBlogsWithWriterCategory()
		{
			return _blogRepository.GetBlogsWithWriterCategory();
		}

		public IEnumerable<Blog> GetLastBlogsByWriter(int id)
		{
			return _blogRepository.GetLastBlogsByWriter(id);
		}

		public IEnumerable<Blog> GetOnlyLastFourBlog() // Son 4 blogu getir
		{
			return _blogRepository.GetOnlyLastFourBlog();
		}
		/*
Buradaki Constuctor metodu yani BlogService class'ından bir nesne oluşturulduğu anda çalışacak metot, 
miras aldığı GenericService<Blog> classının constructor'ırına ": base(repository)" ifadesi ile 
"IBlogRepository<Blog>" tipinde oluşturduğu "repository" nesnesini gönderiyor.
*/


		public IEnumerable<Blog> GetAllBlogByWriter(int id)
		{
			return _blogRepository.GetAllBlogByWriter(id);
		}

		public void SetNullBlogWillBeDeleteCategory(int id) //  Kategoriyi silmeden önce kategoriye ait Blogların KategoriID değerini NULL yap
		{
			var blogs = _blogRepository.GetAllBlogsByCategory(id);
			if (blogs != null)
			{
				foreach (var item in blogs)
				{
					item.CategoryID = null;
					_blogRepository.Update(item);
				}
			}
		}
		public IEnumerable<Blog> GetAllBlogsByCategory(int id)
		{
			return _blogRepository.GetAllBlogsByCategory(id);
		}
		public int GetCountBlogsByCategory(int id)
		{
			return _blogRepository.GetCountBlogsByCategory(id);
		}

		public Blog GetBlogByIdIncludeWriterCategory(int id)
		{
			return _blogRepository.GetBlogByIdIncludeWriterCategory(id);
		}
		public Blog GetLastBlogByCategory(int id) // Kategoriye göre son bloğu getir
		{
			return _blogRepository.GetLastBlogByCategory(id);
		}
	}
}
