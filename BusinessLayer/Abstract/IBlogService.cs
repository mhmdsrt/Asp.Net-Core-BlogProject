using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService:IGenericService<Blog>
    {
		IEnumerable<Blog> GetBlogsWithWriterCategory();
		IEnumerable<Blog> GetLastBlogsByWriter(int id);
		public IEnumerable<Blog> GetAllBlogByWriter(int id); // ilgili yazarın tüm bloglarını getir.

		public IEnumerable<Blog> GetOnlyLastFourBlog(); // Son 4 blogu getir.

		public void SetNullBlogWillBeDeleteCategory(int id); //  Kategoriyi silmeden önce kategoriye ait Blogların KategoriID değerini NULL yap
		public IEnumerable<Blog> GetAllBlogsByCategory(int id);

	}
}
