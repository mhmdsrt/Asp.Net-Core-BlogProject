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

	}
}
