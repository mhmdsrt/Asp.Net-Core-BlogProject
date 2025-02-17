using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class NotificationService : GenericService<Notification>, INotificationService
	{
		private readonly INotificationRepository _notificationRepository;
		public NotificationService(INotificationRepository repository):base(repository)
		{
			_notificationRepository = repository;
		}
	}
}
