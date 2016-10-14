using System;
using Quote.Helpers;

namespace Quote.Writers
{
    public class ConsoleOutputStream:IOutputStream
    {
        public void Write(QuoteResults quote)
        {
            Console.WriteLine("Requested amount:£{0}", quote.LoanAmount);
            Console.WriteLine("Rate:{0}%", Math.Round(quote.QuoteRate*100,1));
            Console.WriteLine("Monthly repayment:£{0}",quote.MonthlyRepayment);
            Console.WriteLine("Total repayment:£{0}",quote.TotalRepayment);
        }

        public void NoQuoteMessage()
        {
            Console.WriteLine("It is not possible to provide a quote now. Try again later");
        }
    }
}
