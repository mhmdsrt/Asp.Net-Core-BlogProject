using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; } // Decription -> tanım, tanımlama
        public bool CategoryStatus { get; set; }

        public ICollection<Blog> Blogs { get; set; } // Her bir kategoride birden fazla Blog olabileceğinden dolayı.
        // IEnumerable<T> sadece veri okuma işlemlerinde kullanılabilir,Insert ve Delete işlemlerini desteklemez. Dolasıyla ICollection tipi IEnumerable'ye göre daha iyi bir seçimdir.

        /*
        List<> yerine ICollection<> kullanmamızın nedenleri başka koleksiyon türüne geçmek istediğimizde bu sürecin daha kolay olması.
       List<> daha fazla özellik içerdiği için daha fazla bellek tüketebilir. Yani fazladan ve metotlar içerdiğinden daha fazla yük oluşturabilir.
       Yani List<> EF CORE için açısından gereksiz özellikler barındırdığı için List<> değil ICollection önerilir.
       List<> somut bir sınıf, ICollection ise bir interfacedir.
       ICollection daha hızlı ve esnektir List<> ' e göre.


        */


        /*
       Burada Blog sınıfı ile Category sınıfı arasında ilşki kurarken yukarıda yazdığımız List<T> yerine ICollection<T> kullanmamızın 
       sebepleri şunlardır:
       1) ICollection<T> daha geniş bir koleksiyon Interfacedir.
       Yani içerisinde List<T>,HashSet<T>,LinkedList<T> gibi koleksiyonları kapsar. İleride List<T> kolesiyonundan
       HashSet<T> koleksiyonuna geçmek istediğimizde değiştirmeye gerek kalmayacaktır çünkü ICollection<T> hepsini kapsıyor.
       Yani ileride Farklı bir ICollection<T> içerisinde bulunan koleksiyona geçmek istediğimizde bu geçiş performans artışı sağlayabilir.
       Ayrıca kod değişikliğini minimize eder.
       */


    }
}
