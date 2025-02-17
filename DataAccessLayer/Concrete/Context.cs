using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    /*
     ORM (Object-Relational Mapping) -> Nesne-İlişkisel Eşleme
     Nesne yönelimli progralama ile Veri tabanı arasında köprü görevi görevi görür.
     Class'ı tablo, property'leri ise sütun olarak eşler.

     Bu projede ORM aracı olarak Entity Framework kullanıyoruz.
     */
    public class Context : DbContext
    {
        /*
            Builder -> Kurucu
            Configuration -> Yapılandırma
            Options -> Seçenekler
            integrated -> Entegre
            security -> güvenlik
            on -> üzerinde
         */
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Blog> Blogs { get; set; } // Projemizde Blog Classını Database'de Blogs isimdeki tabloya dönüştürüyoruz.
        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}
