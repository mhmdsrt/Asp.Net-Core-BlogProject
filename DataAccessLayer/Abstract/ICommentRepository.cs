using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	/*
     ICommentRepository interface'ini miras alıcak sınıflar hem ICommentRepository interface'indeki metotları 
    hemde IGenericRepository interface'indeki metotları <Comment> tipinde implement etmek zorundadır.

     Çünkü ICommentRepository İnterface'i IGenericRepository interface'inden miras almıştır.
     */
	public interface ICommentRepository : IGenericRepository<Comment>
	{
		public IEnumerable<Comment> GetCommentsByBlog(int id);
		public int GetCommentCountByBlog(int id);

	}
}
