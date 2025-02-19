using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Message
	{
		[Key]
		public int MessageID { get; set; }
		public string? MessageReceiverMail { get; set; } // Receiver -> Alıcı
		public string? MessageSubject { get; set; } // Subject Konu
		public string? MessageDetails { get; set; } // Subject Konu
		public DateTime MessageCreateDate { get; set; }
		public bool MessageStatus { get; set; }
		public int WriterID { get; set; } // Her mesajın bir yazarı olduğundan dolayı.
		public virtual Writer Writer { get; set; } // Üstünden çalıştığımız Message nesnesi üzerinden ait olduğu Writer'ın propertylerine ulaşabilmek için Navigation Property'sini kullandık.
	}
}
