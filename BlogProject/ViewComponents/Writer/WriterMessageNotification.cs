using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Writer
{
	public class WriterMessageNotification : ViewComponent
	{
		private readonly IMessageService _messageService;
		public WriterMessageNotification(IMessageService messageService)
		{
			_messageService = messageService;
		}
		public IViewComponentResult Invoke()
		{
			ViewBag.MessageCount = _messageService.MessageCountByReceiver(User.Identity.Name);

			return View(_messageService.GetAllMessageByReceiver(User.Identity.Name));
		}
	}
}
