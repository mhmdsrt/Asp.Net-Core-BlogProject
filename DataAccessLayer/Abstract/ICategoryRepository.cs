using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    /*
     ICategoryRepository interface'ini miras alıcak sınıflar hem ICategoryRepository interface'indeki metotları hemde 
     IGenericRepository interface'indeki metotları <Category> tipinde implement etmek zorundadır.

     Çünkü ICategoryRepository İnterface'i IGenericRepository interface'inden miras almıştır.
     */
    public interface ICategoryRepository:IGenericRepository<Category> 
    {
    }
}
