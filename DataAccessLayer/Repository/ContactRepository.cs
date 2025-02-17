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
	public class ContactRepository : GenericRepository<Contact>, IContactRepository
	{
		public ContactRepository(Context context) : base(context)
		{
		}
	}

	/*
     Bu class yani ContactRepository sınıfı, Generic_Repository sınıfından <Contact> tipinde miras alarak 
     IContactRepository interface'ini implement etmiş oluyor.

    ContactRepository sınıfı Generic_Repository<T> sıfından miras aldığından dolayı ve
    T yerine Contact ile verdiğinden Generic_Repository<Contact> classının tüm metotlarını kullanabiliyor Contact tipinde.

     */
}
