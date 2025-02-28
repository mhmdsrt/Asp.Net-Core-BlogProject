using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
	public class MessageController : Controller
	{
		private readonly IMessageService _messageService;
		private readonly IWriterService _writerService;
		public MessageController(IMessageService messageService,IWriterService writerService)
		{
			_messageService = messageService;
			_writerService = writerService;
		}
		public IActionResult WriterInBox(string receiverMail)
		{
			return View(_messageService.GetAllMessageByReceiver(User.Identity.Name));
		}

		public IActionResult WriterInboxDetail(int id)
		{
			return View(_messageService.GetMessageByIdWithWriter(id));
		}

		[HttpGet]
		public IActionResult SendMessage(int id)
		{
			ViewBag.WriterImage = _writerService.GetWriterImageById(id);
			ViewBag.WriterName = _writerService.GetWriterNameById(id);
			ViewBag.WriterMail = _writerService.GetWriterMailById(id);
			ViewBag.WriterID = id;
			return View();
		}
		[HttpPost]
		public IActionResult SendMessage(Message entity,int id)
		{
			MessageValidator messageValidator = new MessageValidator();
			ValidationResult validationResult = messageValidator.Validate(entity);
			if (!validationResult.IsValid)
			{
				foreach(var item in validationResult.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			entity.WriterID = _writerService.GetWriterIdByMail(User.Identity.Name); // Mesajı gönderen kisi sisteme başarılı giriş yapmış yazar olacağandan
			entity.MessageReceiverMail = _writerService.GetWriterMailByWriterId(id); // Mesajı Alacak kisi
			entity.MessageStatus = true;
			entity.MessageCreateDate = DateTime.Parse(DateTime.Now.ToLongDateString());
			_messageService.Insert(entity);
			return RedirectToAction("WriterInBox", "Message");
		}

		[HttpGet]
		public IActionResult NewMessage()
		{
			return View();
		}

		[HttpPost]
		public IActionResult NewMessage(Message entity,int id)
		{
			MessageValidator messageValidator = new MessageValidator();
			ValidationResult validationResult = messageValidator.Validate(entity);
			if (!validationResult.IsValid)
			{
				foreach (var item in validationResult.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			entity.WriterID = _writerService.GetWriterIdByMail(User.Identity.Name); // Mesajı gönderen kisi sisteme başarılı giriş yapmış yazar olacağandan
			entity.MessageStatus = true;
			entity.MessageCreateDate = DateTime.Parse(DateTime.Now.ToLongDateString());
			_messageService.Insert(entity);
			return RedirectToAction("WriterInBox", "Message");
		}


	}
}
