using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Blog
{
	public class GetLastBlogs:ViewComponent
	{
		private readonly IBlogService _blogService;

		public GetLastBlogs(IBlogService blogService)
		{
			_blogService = blogService;
		}
		public IViewComponentResult Invoke()
		{
			return View(_blogService.GetOnlyLastFourBlog());
		}
	}
}
