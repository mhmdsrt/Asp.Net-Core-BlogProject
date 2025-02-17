using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	/*
	  Ctrl + Shift + Space => Metodun farklı overload'larını görebilmemizi sağlar.
	 */
	public class BlogRepository : GenericRepository<Blog>, IBlogRepository
	{
		private readonly Context _context;
		public BlogRepository(Context context) : base(context)
		{
			_context = context;
		}
		public IEnumerable<Blog> GetBlogsWithWriterCategory()
		{

			return _context.Blogs.Include(x => x.Category).Include(y => y.Writer).ToList();  // Tüm Blogları, Kategori ve Yazarı dahil ederek getir.
			/*
			  Include => Dahil etmek.
			  Then => Daha sonra.
			  Include() metodu doğrudan ilişkili varlıkları yüklemek için kullanılır.
			  ThenInclude() metodu iç içe ilişkili varlıkları yüklemek için kullanılır.(Dolaylı yoldan ilişkili olanı getirmek için)
			  Yukarıda Category ve Writer doğrudan Blog ile ilişkili olduğundan Include() kullandık.			
			 */


		}

		public IEnumerable<Blog> GetLastBlogsByWriter(int id) // Yazarın son 4 bloğunu getir
		{

			return _context.Blogs.Where(x => x.WriterID == id).OrderByDescending(x => x.BlogID).Take(4); // Take(n) -> ilk n kaydır getirir
		}

		public IEnumerable<Blog> GetOnlyLastFourBlog() // Son 4 Bloğu getir
		{

			return _context.Blogs.OrderByDescending(x => x.BlogID).Take(4); // Take(n) -> ilk n kaydır getirir
		}

		public IEnumerable<Blog> GetAllBlogByWriter(int id) // ilgili yazarın tüm bloglarını getir.
		{
			return _context.Blogs.Where(x => x.WriterID == id).Include(x=>x.Category).Include(x=>x.Writer).ToList();
		}

	}
	/*
     Bu class yani BlogRepository sınıfı, Generic_Repository sınıfından <Blog> tipinde miras alarak 
     IBlogRepository interface'ini implement etmiş oluyor.

    BlogRepository sınıfı Generic_Repository<T> sıfından miras aldığından dolayı ve
    T yerine Blog ile verdiğinden Generic_Repository<Blog> classının tüm metotlarını kullanabiliyor Blog tipinde.

     */
}
