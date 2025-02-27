using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment // Comment -> Yorum
    {
        [Key]
        public int CommentID { get; set; }
        public string? CommentUserName { get; set; }
        public string? CommentTitle { get; set; }
        public string? CommentContent { get; set; }
        public DateTime CommentCreateDate { get; set; }
        public bool CommentStatus { get; set; }

        public int? BlogID { get; set; } // Foreing key tanımlaması. Her yorumun ait olduğu bir blog olduğundan dolayı.

        public virtual Blog Blog { get; set; } // Üzerinden calıştığımız Yoruma ait Blog'un propertylerine ulaşabilmek için navigation property'si tanımladık.
        // Ayrıca "public virtual Blog Blog { get; set; }" kodu sayesinde üzerinde çalıştığımız Comment'e ait Blog Propertylerine oradan da
        // Writer ve Category nesneslerinin propertylerine ulaşabiliyoruz. Blog Classında Writer ve Categoru Navigation Propertysi olarak tanımladığı
        // bunu yapabiliyoruz.
        // Kısaca Comment üzerinden Blog'a, Blogtan da Writer ve Category propertylerine erişebiliyoruz.
    }
}
