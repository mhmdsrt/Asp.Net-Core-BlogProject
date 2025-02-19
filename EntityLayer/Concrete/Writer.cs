using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Writer // Writer -> Yzar
	{
		[Key]
		public int WriterID { get; set; }
		public string? WriterName { get; set; } // ? işareti boş geçilebilir yapıyor
		public string? WriterAbout { get; set; } // About Hakkında
		public string? WriterImage { get; set; }
		public string? WriterMail { get; set; }
		public string? WriterPassword { get; set; }
		public bool WriterStatus { get; set; }
		public ICollection<Blog> Blogs { get; set; } // Bir Yazar birden fazla blog yazabilir.
		public ICollection<Message> Messages { get; set; } // Bir yazarın birden fazla mesajı olabilir
	}
}
