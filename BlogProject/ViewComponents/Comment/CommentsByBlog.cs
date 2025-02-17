using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Comment
{
	public class CommentsByBlog : ViewComponent
	{
		private readonly ICommentService _commentService;
		public CommentsByBlog(ICommentService commentService)
		{
			_commentService = commentService;
		}
		public IViewComponentResult Invoke(int id)
		{
			/*
		       buradaki parametre değeri BlogDetail.cshtml sayfasından 
			  "@await Component.InvokeAsync("CommentsByBlog", new {id=ViewBag.BlogID})" 'dan gelen BlogID değeridir.

		     */

			return View(_commentService.GetCommentsByBlog(id));
			/*
			 Shared/Components/CommentsByBlog/default.cshtm sayfasını döndür ve o sayfaya döndürürkende gene o sayfaya 
			"(commentService.GetCommentsByBlog(id)" gelen değeri model olarak gönder.
			 */
		}
	}
}
