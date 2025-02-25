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
	public class WriterRepository : GenericRepository<Writer>, IWriterRepository
	{
		private readonly Context _context;
		public WriterRepository(Context context) : base(context)
		{
			_context = context;
		}

		public int GetWriterIdByMail(string writerMail)// Parametre olarak maili verilen yazarın id'sini döndür
		{
			return _context.Writers.Where(x => x.WriterMail == writerMail).Select(y => y.WriterID).FirstOrDefault();
		}

		public int GetTotalWriterCount()
		{
			return _context.Writers.Count();
		}
	}
	/*
     Bu class yani WriterRepository sınıfı, Generic_Repository sınıfından <Writer> tipinde miras alarak 
     IWriterRepository interface'ini implement etmiş oluyor.

    WriterRepository sınıfı Generic_Repository<T> sıfından miras aldığından dolayı ve
    T yerine Writer ile verdiğinden Generic_Repository<Writer> classının tüm metotlarını kullanabiliyor Writer tipinde.

     */
}
