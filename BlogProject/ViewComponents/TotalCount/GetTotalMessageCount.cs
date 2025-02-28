using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.TotalCount
{
	public class GetTotalMessageCount:ViewComponent
	{
		private readonly IMessageService _messageService;
		public GetTotalMessageCount(IMessageService messageService)
		{
			_messageService = messageService;
		}

		public IViewComponentResult Invoke()
		{
			return View(_messageService.GetTotalMessageCount());
		}
	}
}
