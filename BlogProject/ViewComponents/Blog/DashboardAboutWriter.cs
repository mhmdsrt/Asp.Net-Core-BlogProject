using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Blog
{
	public class DashboardAboutWriter:ViewComponent
	{
		private readonly IWriterService _writerService;
		public DashboardAboutWriter(IWriterService writerService)
		{
			_writerService = writerService;
		}
		public IViewComponentResult Invoke()
		{
			return View(_writerService.GetById(_writerService.GetWriterIdByMail(User.Identity.Name)));
		}
	}
}
