using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Writer
{
	public class WriterNotification:ViewComponent
	{
		private readonly INotificationService _notificationService;
		public WriterNotification(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}
		public IViewComponentResult Invoke()
		{
			return View(_notificationService.GetAll());
		}
	}
}
