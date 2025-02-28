using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService:IGenericService<Writer>
    {
		public int GetWriterIdByMail(string writerMail);
		public int GetTotalWriterCount();
		public string GetWriterImageById(int id);

		public string GetWriterNameById(int id);
		public string GetWriterMailById(int id);

		public string GetWriterMailByWriterId(int id);

	}
}
