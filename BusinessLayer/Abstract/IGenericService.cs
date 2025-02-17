using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T :class
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Insert(T entity);

        void Delete(int id);

        void Update(T entity);
    }
}
