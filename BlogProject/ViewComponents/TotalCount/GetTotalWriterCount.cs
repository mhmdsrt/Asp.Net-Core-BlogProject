using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.TotalCount
{
	public class GetTotalWriterCount:ViewComponent
	{
		private readonly IWriterService _writerService;
		public GetTotalWriterCount(IWriterService writerService)
		{
			_writerService = writerService;
		}

		public IViewComponentResult Invoke()
		{
			return View(_writerService.GetTotalWriterCount());
		}
	}
}
