using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IMessageService : IGenericService<Message>
	{
		public IEnumerable<Message> GetAllMessageByReceiver(string receiverMail);
		public int MessageCountByReceiver(string receiverMail);
		public Message GetMessageByIdWithWriter(int id);

	}
}
