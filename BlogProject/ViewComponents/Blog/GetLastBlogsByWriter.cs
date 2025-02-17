using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Blog
{
	public class GetLastBlogsByWriter : ViewComponent
	{
		private readonly IBlogService _blogService;

		public GetLastBlogsByWriter(IBlogService blogService)
		{
			_blogService = blogService;
		}
		public IViewComponentResult Invoke(int id)
		{

			return View(_blogService.GetLastBlogsByWriter(id));
		}
	}
}
