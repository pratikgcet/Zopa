using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using Quote.CalculationGrid;
using Quote.Readers;
using Quote.Writers;

namespace Quote
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Havent used any library for Dependecy Injection. Wanted to keep it simple and small

            IReader reader=new CSVFileReader();
            IOutputStream output=new ConsoleOutputStream();
            ICalculator calculator=new QuoteCalculator();

            CalculateRateApp calc = new CalculateRateApp(reader,output,calculator,36);
            try
            {
                calc.Run(args);
            }
            catch (Exception exception)
            {   
                Console.WriteLine(exception.Message);
            }
            
        }
    }
}
