using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Writer
{
	public class WriterLayoutProfile : ViewComponent
	{
		private readonly IWriterService _writerService;
		public WriterLayoutProfile(IWriterService writerService)
		{
			_writerService = writerService;
		}

		public IViewComponentResult Invoke()
		{
			return View(_writerService.GetById(_writerService.GetWriterIdByMail(User.Identity.Name)));
		}
	}
}
