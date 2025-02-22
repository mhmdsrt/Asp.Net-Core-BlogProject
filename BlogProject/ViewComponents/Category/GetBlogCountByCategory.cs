using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Category
{
	public class GetBlogCountByCategory : ViewComponent
	{
		private readonly IBlogService _blogService;
		public GetBlogCountByCategory(IBlogService blogService)
		{
			_blogService = blogService;
		}
		public IViewComponentResult Invoke(int id)
		{
			return View(_blogService.GetCountBlogsByCategory(id));
		}
	}
}
