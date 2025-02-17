using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    /*
   IContactRepository interface'ini miras alıcak sınıflar hem IContactRepository interface'indeki metotları
   hemde IGenericRepository interface'indeki metotları <Contact> tipinde implement etmek zorundadır.

   Çünkü IContactRepository İnterface'i IGenericRepository interface'inden miras almıştır.
   */
    public interface IContactRepository:IGenericRepository<Contact> 
    {
    }
}
