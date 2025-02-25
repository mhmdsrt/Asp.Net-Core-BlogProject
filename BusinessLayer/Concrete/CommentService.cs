using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class CommentService : GenericService<Comment>, ICommentService
	{
		private readonly ICommentRepository _repository;
		public CommentService(ICommentRepository repository) : base(repository)
		{
			_repository = repository;

		}

		public IEnumerable<Comment> GetCommentsByBlog(int id)
		{
			return _repository.GetCommentsByBlog(id);
		}

		public void SetNullCommentWillBeDeleteBlog(int id) // Bloğu silmeden önce bloğa ait yorumla NULL yapma
		{
			/*
			 İlişkili tablolarda veri silme işlemi için "Set null" yöntemini kullandım
			 Burada her yorumun(Comment'in) ait olduğu bir blog olduğundan dolayı bloğu silmeden önce o bloğa ait yorumların ait olduğu BlogID değerini null yapacağız.
			 */
			var commentsToDelete = _repository.GetCommentsByBlog(id); // id'ye ait tüm yorunları getir.
			if (commentsToDelete != null)
			{
				foreach (var item in commentsToDelete) // Eğer Bloğa ait yorumlar varsa her yorumun BlogID değerini null yap.
				{
					item.BlogID = null;
					_repository.Update(item);
				}
			}
		}

		public int GetCommentCountByBlog(int id) // Bloğa ait yorumların sayısını getir
		{
			return _repository.GetCommentCountByBlog(id);
		}

		public int GetTotalCommentCount()
		{
			return _repository.GetTotalCommentCount();
		}
	}
}
