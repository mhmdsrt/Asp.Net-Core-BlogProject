﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	/*
    IBlogRepository interface'ini miras alıcak sınıflar hem IBlogRepository interface'indeki metotları 
    hemde IGenericRepository interface'indeki metotları <Blog> tipinde implement etmek zorundadır.

    Çünkü IBlogRepository İnterface'i IGenericRepository interface'inden miras almıştır.
    */
	public interface IBlogRepository : IGenericRepository<Blog>
	{
		IEnumerable<Blog> GetBlogsWithWriterCategory();
		IEnumerable<Blog> GetLastBlogsByWriter(int id);
		public IEnumerable<Blog> GetAllBlogByWriter(int id);
		public IEnumerable<Blog> GetOnlyLastFourBlog();
		public IEnumerable<Blog> GetAllBlogsByCategory(int id);
		public int GetCountBlogsByCategory(int id);
		public Blog GetBlogByIdIncludeWriterCategory(int id);
		public Blog GetLastBlogByCategory(int id); // Kategoriye göre son bloğu getir
		public int GetTotalBlogCount();


	}
}
