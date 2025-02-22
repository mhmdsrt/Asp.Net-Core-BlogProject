using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Comment
{
	public class GetCommentCountByBlog : ViewComponent
	{
		private readonly ICommentService _commentService;
		public GetCommentCountByBlog(ICommentService commentService)
		{
			_commentService = commentService;
		}
		public IViewComponentResult Invoke(int id)
		{
			return View(_commentService.GetCommentCountByBlog(id));
		}
	}
}
