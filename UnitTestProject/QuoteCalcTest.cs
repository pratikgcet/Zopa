using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using Quote.CalculationGrid;
using Quote.Helpers;

namespace UnitTestProject
{
    /// <summary>
    /// Summary description for QuoteCalcTest
    /// </summary>
    
    [TestFixture]
    public class QuoteCalcTest
    {
        [Test]
        public void GivenLoanAMoubt_WhenRequestedQuote_ShouldReturntheSameAmount()
        {
            var calculator = new QuoteCalculator();

            var result = calculator.ProcessQuoteCalculation(1000, new List<Lenders> {new Lenders() {Amount = 1000}}, 36);
            
            Assert.AreEqual(1000, result.LoanAmount);
        }

        [Test]
        public void GivenListofQuotes_WhenLoanRequested_ThenShouldCalculateLowestQuoteRateFromOffers()
        {
            var calculator = new QuoteCalculator();

            var result = calculator.ProcessQuoteCalculation(1000, new List<Lenders>
            { new Lenders() { Amount = 1000, Rate = 0.075m }, new Lenders() { Amount = 1000, Rate = 0.077m } }, 36);
            
            Assert.AreEqual(0.075m,result.QuoteRate);

        }

        [Test]
        public void GivenListofQuotes_WhenLoanRequested_ThenShouldCalculateCorrectMonthlyRepayments()
        {
            var calculator = new QuoteCalculator();

            var result = calculator.ProcessQuoteCalculation(1000, new List<Lenders>
            { new Lenders() { Amount = 1000, Rate = 0.075m }, new Lenders() { Amount = 1000, Rate = 0.077m } }, 36);
            
            Assert.AreEqual(29.86m,result.MonthlyRepayment);
            
        }

        [Test]
        public void GivenListofQuotes_WhenLoanRequested_ThenShouldCalculateCorrectTotalPayments()
        {
            var calculator = new QuoteCalculator();

            var result = calculator.ProcessQuoteCalculation(1000, new List<Lenders> { new Lenders() 
            { Amount = 520, Rate = 0.075m }, new Lenders() { Amount = 480, Rate = 0.077m } }, 36);

            Assert.AreEqual(1075.96m, result.TotalRepayment);
        }
        
    }
}
