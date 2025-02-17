using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    /*
     interface'lerin içerisindeki metotların erişim belirleyiçleri belirtilmez her zaman public olarak kabul edilir.
     Çünkü interface'i implement edecek Class'ların erişebilmesi lazım.
     */
    public interface IGenericRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        /*
         Eğer sadece okuma işlemi yapılacaksa IEnumerable<T>, ICollection<T> ' e göre daha hızlıdır ve daha az bellek tüketir.
         IEnumerable<T> sadece okuma işlemlerinde kullanılır.
         ICollection<T> ise tüm CRUD işlemlerinde kullanılabilir.
         Ve biz burada GetAll ile sadece listeleme(okuma) yapacağımızdan dolayı List<T> ve ICollection<T> tiplerine göre
         daha az bellek tüketir ve daha hızlıdır(performanslıdır).
         IEnumerable<T>, en hızlı Lazy Loading sağlar.
         */

        T GetById(int id);

        void Insert(T entity); // Veriyi database'e eklerken tüm alanlarıyla beraber ekleyeceğimizden dolayı parametre olarak
        // "int id" değil, "T entity" yaptık.

        void Delete(int id);

        void Update(T entity); // Parametre olarak "int id" değil de "T entity" olmasının sebebi güncellenecek verinin



	}
}
