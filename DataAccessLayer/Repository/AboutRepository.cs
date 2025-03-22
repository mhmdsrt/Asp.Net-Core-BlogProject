using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public class AboutRepository : GenericRepository<About>, IAboutRepository
	{
		/*
		  Miras Aldığı GenericRepository<About2> Constructor'ırına Program.cs'de yazılan Dependecy Injection
		  ile buraya context nesnesi enjekte ediliyor ve enjekte edilen context nesneside GenericRepository classına gönderiliyor.
		  Böylelikle About2Repository Classından bir nesne oluşturulduğu anda tek bir context nesnesi oluşturup, oluşturulan 
		  About2Repository nesnesi üzerinden aynı Context nesnesi kullanılır..
		*/
		public AboutRepository(Context context) : base(context)
		{
		}
	}
	/*
     Bu class yani AboutRepository sınıfı, Generic_Repository sınıfından <About> tipinde miras alarak 
     IAboutRepository interface'ini implement etmiş oluyor.

    AboutRepository sınıfı Generic_Repository<T> sıfından miras aldığından dolayı ve
    T yerine About ile verdiğinden Generic_Repository<About> classının tüm metotlarını kullanabiliyor About tipinde.

     */
}
