using System;
using System.Collections.Generic;
using System.Linq;
using Quote.Helpers;

namespace Quote.CalculationGrid
{
    public class QuoteCalculator : ICalculator
    {
        public QuoteResults ProcessQuoteCalculation(int loanAmount, IList<Lenders> offers, int loanLength)
        {
            var totalPayment = CalculateTotalPayment(loanAmount, offers);
            var rate = (totalPayment - loanAmount) / loanAmount;

            var monthlyRepayment = loanAmount * (1 + rate) / loanLength;

            return new QuoteResults(loanAmount, Math.Round(rate, 4), Math.Round(monthlyRepayment, 2),
                Math.Round(totalPayment, 2));
        }


        private decimal CalculateTotalPayment(int loanAmount, IEnumerable<Lenders> rateOffers)
        {
            decimal totalPayment = 0;
            int amountLeft = loanAmount;

            foreach (var offer in rateOffers.OrderBy(a => a.Rate))
            {
                var borrowAmount = offer.Amount > amountLeft ? amountLeft : offer.Amount;
                totalPayment += borrowAmount + (borrowAmount * offer.Rate);
                amountLeft = amountLeft - borrowAmount;

                if (amountLeft == 0)
                    break;
            }

            return totalPayment;
        }
    }
}
