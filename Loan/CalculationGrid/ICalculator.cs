using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quote.Helpers;

namespace Quote.CalculationGrid
{
    public interface ICalculator
    {
        QuoteResults ProcessQuoteCalculation(int loanAmount, IList<Lenders> offers, int loanLength);
    }
}
