using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using Quote.Helpers;

namespace Quote.Readers
{
    public class CSVFileReader:IReader
    {
        public IList<Lenders> Read(string file)
        {
            using (var reader = new CsvReader(File.OpenText(file)))
            {
                return reader.GetRecords<CSV>().Select(x => new Lenders { Name = x.Lender, Rate = x.Rate, Amount = x.Available }).ToList();
            }
        }

        private class CSV
        {
            public string Lender { get; set; }

            public decimal Rate { get; set; }

            public int Available { get; set; }
        }
    }
}
