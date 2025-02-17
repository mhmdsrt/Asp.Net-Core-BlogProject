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
    public class AboutService : GenericService<About>, IAboutService
    {
        private readonly IAboutRepository _aboutRepository;

		public AboutService(IAboutRepository repository) : base(repository) 
        {
			_aboutRepository = repository;

		}

    }
}
