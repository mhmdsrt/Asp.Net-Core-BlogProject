using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterService : GenericService<Writer>, IWriterService
    {
        private readonly IWriterRepository _writerRepository;
        public WriterService(IWriterRepository repository) : base(repository)
        {
            _writerRepository = repository;

		}
		public int GetWriterIdByMail(string writerMail)
        {
            return _writerRepository.GetWriterIdByMail(writerMail);
        }
         public int GetTotalWriterCount()
        {
            return _writerRepository.GetTotalWriterCount();
        }
		public string GetWriterImageById(int id)
        {
            return _writerRepository.GetWriterImageById(id);
        }
		public string GetWriterNameById(int id)
        {
            return _writerRepository.GetWriterNameById(id);
        }
		public string GetWriterMailById(int id)
		{
			return _writerRepository.GetWriterMailById(id);
		}

		public string GetWriterMailByWriterId(int id)
        {
            return _writerRepository.GetWriterMailByWriterId(id);
        }


	}
}
