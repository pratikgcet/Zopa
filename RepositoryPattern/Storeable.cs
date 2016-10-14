using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    public class Storeable : IStoreable
    {
        public IComparable Id { get; set; }
    }
}
