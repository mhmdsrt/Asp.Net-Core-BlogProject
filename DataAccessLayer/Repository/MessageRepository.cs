using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public class MessageRepository : GenericRepository<Message>, IMessageRepository
	{
		private readonly Context _context;
		public MessageRepository(Context context) : base(context)
		{
			_context = context;
		}

		public IEnumerable<Message> GetAllMessageByReceiver(string receiverMail) // Alıcı yazarın tüm mesajlarını getir
		{
			return _context.Messages.Include(x => x.Writer).Where(y=>y.MessageReceiverMail==receiverMail);
		}

		public int MessageCountByReceiver(string receiverMail) // Alıcı yazara gelen toplam mesaj sayısı
		{
			return _context.Messages.Where(x => x.MessageReceiverMail == receiverMail).Count();
		}

		public Message GetMessageByIdWithWriter(int id) // ID ye göre mesajı getir yazar bilgileri ile
		{
			return _context.Messages.Include(x => x.Writer).Where(y => y.MessageID == id).FirstOrDefault();
		}

		public int GetTotalMessageCount()
		{
			return _context.Messages.Count();
		}

		public Message GetByIdMessageIncludeWriter(int id) // Parameredeki ıd ye göre mesajı getiren yazarı dahil ederek
		{
			return _context.Messages.Where(m => m.MessageID == id).Include(w => w.Writer).FirstOrDefault();
		}
	}
}
