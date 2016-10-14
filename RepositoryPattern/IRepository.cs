using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    public interface IRepository<T> where T : IStoreable
    {
        IEnumerable<T> All();
        void Delete(IComparable id);
        void Save(T item);
        T FindById(IComparable id);
    }
}
