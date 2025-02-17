using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        /*
       "Context c = new Context();"   değilde    "using var context = new Context();"   kullanma sebebimiz şunlardır:
       "using var context = new Context();" kullandığımız zaman using bloğunun scope(kapsamı) bittiği anda Dispose() metodu otomatik çağrılır.
        Dispose() metodu sayesinde oluşturulan "context" nesnesinin kullandığı kaynakların(örneğin veri tabanı bağlantısı gibi) serbest bırakılmasını sağlar.
        Bundan dolay "using var context = new Context();" daha güvenli ve temiz bir kullanım sağlar.
        Ama "Context c = new Context();" kullansaydık kaynakları serbest bırakmak için Dispose() metodunu manuel olarak kendimiz yazacaktık. Vu bu Dispose()
        metodunu doğru yerde yazmamız lazımdı. 
        Eğer Dispose() metodu çağırılmazsa kullanılan kaynaklar(örneğin veritabanı bağlantısı) açık kalabilir buda kaynak sızıntılarına ve performans kaybına
        sebep olabilir.
        
         */

        /*
         Her metot için ayrı ayrı "using var context = new Context();" kullanma sebebimiz bağlantı sızıntılarını önlemek ve
         aynı anda yapılan birden fazla işlemlerde çakışmaları önlemektir.
         */

        private readonly Context _context;
		public GenericRepository(Context context)
		{
            _context = context;
		}
		public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Insert(T entity)
        {
			_context.Set<T>().Add(entity);
			_context.SaveChanges();
        }

        public void Delete(int id)
        {
            var dataToDelete = _context.Set<T>().Find(id);
			_context.Remove(dataToDelete);
			_context.SaveChanges();

        }

        public void Update(T entity)
        {
			_context.Set<T>().Update(entity);
			_context.SaveChanges();

        }
    }
}
