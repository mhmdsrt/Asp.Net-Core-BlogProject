using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
	public class MessageController : Controller
	{
		private readonly IMessageService _messageService;
		public MessageController(IMessageService messageService)
		{
			_messageService = messageService;
		}
		public IActionResult WriterInBox(string receiverMail)
		{
			return View(_messageService.GetAllMessageByReceiver(User.Identity.Name));
		}

		public IActionResult WriterInboxDetail(int id)
		{
			return View(_messageService.GetMessageByIdWithWriter(id));
		}
	}
}
