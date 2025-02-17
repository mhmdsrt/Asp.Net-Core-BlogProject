using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact // Contact -> irtibat kurmak, bağlantı kurmak, temasa geçmek, Bize Ulaşın bölümün karşılığı
    {
        [Key]
        public int ContactID { get; set; }
        public string? ContactUserName { get; set; }
        public string? ContactUserMail { get; set; }
        public string? ContactSubject { get; set; } // Subject -> konu, Atılan mailin konusu
        public string? ContactMessage { get; set; } // Atılan mailin içeriği
        public DateTime ContactCreateDate { get; set; }
        public bool ContactStatus { get; set; }
    }
}
