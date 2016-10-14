using System;
using System.Collections.Generic;
using System.Linq;
using Quote.CalculationGrid;
using Quote.Helpers;
using Quote.Readers;
using Quote.Writers;

namespace Quote
{
    public class CalculateRateApp
    {
        private int maxLoanAmount = 15000;
        private const int loanFactor = 100;
        private int _loanAmount = 1000;
        private string _file = "";
        private readonly int _loanLength = 0;

        private readonly IReader _reader;
        private readonly IOutputStream _output;
        private readonly ICalculator _quoteCalc;

        public CalculateRateApp(IReader reader,IOutputStream output,ICalculator calculator,int loanLength)
        {
            _reader = reader;
            _output = output;
            _loanLength = loanLength;
            _quoteCalc = calculator;
        }

        public void Run(IList<string> args)
        {
            if (args==null || args.Count<2)
            {   
                throw new ArgumentException("Incorrect number of params");
            }

            ParseArgument(args);

            var offers = _reader.Read(_file);

            var isEligible=CheckEligibility(_loanAmount, offers);
            if (isEligible)
            {
                var results = _quoteCalc.ProcessQuoteCalculation(_loanAmount, offers, _loanLength);
                _output.Write(results);
            }
            else
            {
                _output.NoQuoteMessage();
            }
        }

        private bool CheckEligibility(int loanAmount, IEnumerable<Lenders> offers)
        {
            var totalAmount = offers.Sum(i => i.Amount);

            return loanAmount <= totalAmount;
        }

        private void ParseArgument(IList<string> args)
        {
            
           if (!int.TryParse(args[1], out _loanAmount))
                    throw new ArgumentNullException();

            if (_loanAmount < 1000)
                throw new ArgumentException("Minimum loan amount should be 1000");

            if (_loanAmount%loanFactor!=0)
                throw new ArgumentException("Loan amount should be in multiple of 1000's");

            if (_loanAmount > maxLoanAmount)
                throw new ArgumentException("Loan amount should be in less than 15000");

            _file = args[0];

            

        }
    }
}
