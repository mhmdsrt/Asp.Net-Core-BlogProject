using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    /*
     * 
   IWriterRepository interface'ini miras alıcak sınıflar hem IWriterRepository interface'indeki metotları
   hemde IGenericRepository interface'indeki metotları <Writer> tipinde implement etmek zorundadır.

   Çünkü IWriterRepository İnterface'i IGenericRepository interface'inden miras almıştır.
   */
    public interface IWriterRepository : IGenericRepository<Writer>
    {
        public int GetWriterIdByMail(string writerMail);

	}
}
