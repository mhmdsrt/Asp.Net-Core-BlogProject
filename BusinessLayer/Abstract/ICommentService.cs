using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ICommentService : IGenericService<Comment>
	{
		IEnumerable<Comment> GetCommentsByBlog(int id);
		public void SetNullCommentWillBeDeleteBlog(int id); // Bloğu silmeden önce bloğa ait yorumla NULL yapma
		public int GetCommentCountByBlog(int id);
		public int GetTotalCommentCount();
	}
}
