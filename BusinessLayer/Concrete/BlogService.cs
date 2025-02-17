using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
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

	}
}
