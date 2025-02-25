using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Areas.Admin.ViewComponents
{
	public class GetTotalBlogCount:ViewComponent
	{
		private readonly IBlogService _blogService;

		public GetTotalBlogCount(IBlogService blogService)
		{
			_blogService = blogService;
		}

		public IViewComponentResult Invoke()
		{
			return View(_blogService.GetTotalBlogCount());
		}


	}
}
