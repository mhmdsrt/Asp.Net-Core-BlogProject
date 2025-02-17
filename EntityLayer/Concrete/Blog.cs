using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {

		/*
         İSİMLENDİRME KURALLARI
         
         Method -> PascalCase -> Örnek : GetAllBlogs()
         Property -> PascalCase ->  Örnek : public int BlogID { get; set; }
         Method Parametreleri -> camelCase -> Örnek :  blogService
         Field (Özel Değişkenler) -> _camelCase -> Örnek _categoryService
         */
		[Key]
        public int BlogID { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogContent { get; set; } // Content -> İçerik
        public string? BlogThumbnailImage { get; set; } // Thumbnail -> küçük resim
        public string? BlogImage { get; set; }
        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }

        public ICollection<Comment> Comments { get; set; } // Bir bloğa ait birden fazla yorum olabileceğinden dolayı.

        public int WriterID { get; set; } // Her Bloğun tek bir yazarı olduğundan dolayı.

        public virtual Writer Writer { get; set;} // Üstünden çalıştığımız Blog nesnesi üzerinden ait olduğu Writer'ın propertylerine ulaşabilmek için Navigation Property'sini kullandık.

        public int CategoryID { get; set; } // Foreign Key (İkinci veya yabancı anahtar) tanımlaması yapıyoruz
        /*
         "public int CategoryID { get; set; }" kullanma sebebimiz her bloğun ait olduğu bir Category olduğundan dolayıdır.
          Blog tablosuna "CategoryID" diye bir sütun ekler ve Bloğun hangi kategoriye ait olduğunu gösterir.
         */

        public virtual Category Category { get; set; }
        /*
          "public virtual Category Category { get; set; }" bu özelliğe Navigation Property (Gezinti özelliği) denir.
           Her Blog'un ait olduğu Category'nin Category Class'ı altındaki tüm properyt'lere o anki çalıştığımız Blog nesnesi üzerinden erişebiliyoruz.
           LINQ sorguları ile Blog nesnesini çekerken ilişkili olduğu Category nesnesini de çekebiliriz böylelikle Blog'un bulundugu Category'ye ait
           CategoryName,CategoryStatus,CategoryDescription gibi propertylere ulaşabiliriz.


         */





        /*
        Eğer "public virtual Category Category { get; set; }" Navigation özelliği olan propertysini kullanmasaydık sadece "public int CategoryID { get; set; }"
        propertysini kullansaydık DataBase'de yine ilişki kurulabilirdi(Yani ilişkiyi DataBase düzeyinde kurardı).
        Ama Blog'un ait olduğu Category'ye ait Category sınıfındaki CategoryName,CategoryDescription gibi propertlere ulaşamazdık.
        Yani burada bulunan "public virtual Category Category { get; set; }" propertysi sayesinde o anki kullandığımız Blog'a ait
        Category propertylerine CategoryName,CategoryDescription,CategoryStatus gibi propertlere kod yazarken ulaşabilmemizi sağlıyor.
        Ayrıca biz veri tabanından bir Blog çekerken o Bloğa ait Category bilgilerinin tümünü alabiliriz.
        */
    }
}
