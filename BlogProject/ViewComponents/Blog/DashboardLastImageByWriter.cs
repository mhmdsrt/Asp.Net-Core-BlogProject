using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Blog
{
	public class DashboardLastImageByWriter : ViewComponent
	{
		private readonly IBlogService _blogService;
		private readonly IWriterService _writerService;
		public DashboardLastImageByWriter(IBlogService blogService, IWriterService writerService)
		{
			_blogService = blogService;
			_writerService = writerService;

		}



		public IViewComponentResult Invoke()
		{
			return View(_blogService.GetLastBlogsByWriter(_writerService.GetWriterIdByMail(User.Identity.Name)));
		}
	}
}
