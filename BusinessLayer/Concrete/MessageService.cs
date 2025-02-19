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
	public class MessageService : GenericService<Message>, IMessageService
	{
		private readonly IMessageRepository _messageRepository;

		public MessageService(IMessageRepository repository) : base(repository)
		{
			_messageRepository = repository;
		}

		public IEnumerable<Message> GetAllMessageByReceiver(string receiverMail)
		{
			return _messageRepository.GetAllMessageByReceiver(receiverMail);
		}

		public int MessageCountByReceiver(string receiverMail)
		{
			return _messageRepository.MessageCountByReceiver(receiverMail);
		}

		public Message GetMessageByIdWithWriter(int id)
		{
			return _messageRepository.GetMessageByIdWithWriter(id);
		}

	}
}
