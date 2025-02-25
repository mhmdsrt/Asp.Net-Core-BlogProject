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

		public IEnumerable<Blog> GetLastBlogsByWriter(int id) // Yazarın son 4 bloğunu getir Kategori Durumu Aktif Olan
		{

			return _context.Blogs.Where(x => x.WriterID == id & x.Category.CategoryStatus==true).OrderByDescending(x => x.BlogID).Take(4); // Take(n) -> ilk n kaydır getirir
		}

		public IEnumerable<Blog> GetOnlyLastFourBlog() //  Genel Son 4 Bloğu getir.Kategori Durumu Aktif Olan
		{

			return _context.Blogs.Where(x=>x.Category.CategoryStatus == true).OrderByDescending(x => x.BlogID).Take(4); // Take(n) -> ilk n kaydır getirir
		}

		public IEnumerable<Blog> GetAllBlogByWriter(int id) // ilgili yazarın tüm bloglarını getir.Kategori Durumu Aktif Olan
		{
			return _context.Blogs.Where(x => x.WriterID == id & x.Category.CategoryStatus == true).Include(x=>x.Category).Include(x=>x.Writer).ToList();
		}

		public IEnumerable<Blog> GetAllBlogsByCategory(int id) // Kategoriye göre blogları getir
		{
			return _context.Blogs.Where(x => x.CategoryID == id).Include(y=>y.Category).Include(z=>z.Writer);
		}

		public int GetCountBlogsByCategory(int id) // Kategoriye göre blogların sayısını getir
		{
			return _context.Blogs.Where(x => x.CategoryID == id).Count();
		}

		public Blog GetBlogByIdIncludeWriterCategory(int id) // Id ye göre Bloğu getir ama Kategori ve Yazar ilişkilerini dahil ederek
		{

			return _context.Blogs.Where(i=>i.BlogID==id).Include(x => x.Category).Include(y => y.Writer).FirstOrDefault();  // Tüm Blogları, Kategori ve Yazarı dahil ederek getir.
			/*
			  Include => Dahil etmek.
			  Then => Daha sonra.
			  Include() metodu doğrudan ilişkili varlıkları yüklemek için kullanılır.
			  ThenInclude() metodu iç içe ilişkili varlıkları yüklemek için kullanılır.(Dolaylı yoldan ilişkili olanı getirmek için)
			  Yukarıda Category ve Writer doğrudan Blog ile ilişkili olduğundan Include() kullandık.			
			 */


		}

		public Blog GetLastBlogByCategory(int id) // Kategoriye göre son bloğu getir
		{
			return _context.Blogs.Include(c=>c.Category).Include(w=>w.Writer).Where(x => x.CategoryID == id).OrderByDescending(i => i.BlogID).Take(1).FirstOrDefault();
		}

		public int GetTotalBlogCount()
		{
			return _context.Blogs.Count();
		}
	}
	/*
     Bu class yani BlogRepository sınıfı, Generic_Repository sınıfından <Blog> tipinde miras alarak 
     IBlogRepository interface'ini implement etmiş oluyor.

    BlogRepository sınıfı Generic_Repository<T> sıfından miras aldığından dolayı ve
    T yerine Blog ile verdiğinden Generic_Repository<Blog> classının tüm metotlarını kullanabiliyor Blog tipinde.

     */
}
