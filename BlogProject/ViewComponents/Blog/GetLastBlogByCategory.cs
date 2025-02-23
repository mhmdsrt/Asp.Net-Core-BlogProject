using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Blog
{
	public class GetLastBlogByCategory : ViewComponent
	{
		private readonly IBlogService _blogService;
		public GetLastBlogByCategory(IBlogService blogService)
		{
			_blogService = blogService;
		}

		public IViewComponentResult Invoke(int id)
		{
			return View(_blogService.GetLastBlogByCategory(id));		
		}
	}
}
