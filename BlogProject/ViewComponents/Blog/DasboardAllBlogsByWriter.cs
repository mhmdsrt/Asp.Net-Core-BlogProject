using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Blog
{
	public class DasboardAllBlogsByWriter : ViewComponent
	{
		private readonly IBlogService _blogService;
		public DasboardAllBlogsByWriter(IBlogService blogService)
		{
			_blogService = blogService;
		}
		public IViewComponentResult Invoke()
		{

			return View(_blogService.GetAllBlogByWriter(3));
		}
	}
}
