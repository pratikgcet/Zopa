using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    public class Repository<T> : IRepository<T> where T : IStoreable
    {
        private HashSet<T> storeDatabase;
        

        public Repository()
        {
            storeDatabase = new HashSet<T>();
        }
        public IEnumerable<T> All()
        {
            return storeDatabase;
        }

        public void Delete(IComparable id)
        {
            if (id == null) return;
            storeDatabase.RemoveWhere(a => a.Id.Equals(id));
            
        }

        public T FindById(IComparable id)
        {
            return storeDatabase.FirstOrDefault(i => i.Id.Equals(id));
        }

        public void Save(T item)
        {
            if (item==null)return;

            storeDatabase.RemoveWhere(a => a.Id.Equals(item.Id));
            storeDatabase.Add(item);
        }

    }
}
