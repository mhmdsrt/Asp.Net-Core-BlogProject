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
	public class CommentRepository : GenericRepository<Comment>, ICommentRepository
	{
		private readonly Context _context;
		public CommentRepository(Context context) : base(context)
		{
			_context = context;
		}

		public IEnumerable<Comment> GetCommentsByBlog(int id) // İd ' e ait yorumları getir
		{

				return _context.Comments.Where(x => x.BlogID == id).ToList(); // Her hiçbir yorum yoksa null değil boş bir liste dönecek.

			/*
			 Where(x=>x..) Keleksiyonun üzerinde filtreleme yaparak belli bir koşulu sağlayan öğeleri getirir.
			 Select(x=>x...) koleksiyonun her bir öğesini belirli forma dönüştürüp getirir.
		    */
		}

		public int GetCommentCountByBlog(int id) // Bloğa ait yorumların sayısını getir
		{
			return _context.Comments.Where(x => x.BlogID == id).Count();
		}

		public int GetTotalCommentCount()
		{
			return _context.Comments.Count();
		}
	}


}
/*
 Bu class yani CommentRepository sınıfı, Generic_Repository sınıfından <Comment> tipinde miras alarak 
 ICommentRepository interface'ini implement etmiş oluyor.

CommentRepository sınıfı Generic_Repository<T> sıfından miras aldığından dolayı ve
T yerine Comment ile verdiğinden Generic_Repository<Comment> classının tüm metotlarını kullanabiliyor Comment tipinde.

 */

