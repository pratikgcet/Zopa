using System.Collections.Generic;
using Quote.Helpers;

namespace Quote.Readers
{
    public interface IReader
    {
        IList<Lenders> Read(string source);
    }
}
