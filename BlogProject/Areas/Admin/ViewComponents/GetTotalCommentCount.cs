using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Areas.Admin.ViewComponents
{
	public class GetTotalCommentCount:ViewComponent
	{
		private readonly ICommentService _commentService;

		public GetTotalCommentCount(ICommentService commentService)
		{
			_commentService = commentService;
		}

		public IViewComponentResult Invoke()
		{
			return View(_commentService.GetTotalCommentCount());
		}
	}
}
