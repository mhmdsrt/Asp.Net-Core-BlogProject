using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
	{
		private readonly Context _context;
		public CategoryRepository(Context context) : base(context)
		{
			_context = context;
		}

		public string GetCategoryNameById(int id) // ID ye göre Category Adını döndür
		{
			return _context.Categories.Where(x => x.CategoryID == id).Select(n => n.CategoryName).FirstOrDefault();
		}
	}
	/*
     Bu class yani CategoryRepository sınıfı, Generic_Repository sınıfından <Category> tipinde miras alarak 
     ICategoryRepository interface'ini implement etmiş oluyor.

    CategoryRepository sınıfı Generic_Repository<T> sıfından miras aldığından dolayı ve
    T yerine Category ile verdiğinden Generic_Repository<Category> classının tüm metotlarını kullanabiliyor Category tipinde.

     */
}
