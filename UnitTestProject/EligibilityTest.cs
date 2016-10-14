using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Quote;
using Quote.CalculationGrid;
using Quote.Helpers;
using Quote.Readers;
using Quote.Writers;

namespace UnitTestProject
{
    [TestFixture]
    public class EligibilityTest
    {
        [Test]
        public void GivenCorrectinputs_WhenNoMatchFound_ThenNotEligible()
        {
            var reader = new Mock<IReader>();
            reader.Setup(x => x.Read(It.IsAny<string>())).Returns(new List<Lenders>());

            var output = new Mock<IOutputStream>();
            output.Setup(x => x.NoQuoteMessage())
                .Verifiable();

            var calcEngine = new Mock<ICalculator>();

            var args = new[] { "market.csv", 1000.ToString() };

            var calculationApp = new CalculateRateApp(
                reader.Object,
                output.Object,
                calcEngine.Object,36); 

            calculationApp.Run(args);

            output.Verify();
        }

        [Test]
        public void GivenCorrectinputs_WhenRequestedLessThanAvailableMatchFound_ThenEligible()
        {
            var reader = new Mock<IReader>();
            var lender = new Lenders {Name ="Bob",Amount = 1000,Rate = 0.075m};
            reader.Setup(x => x.Read(It.IsAny<string>())).Returns(new List<Lenders>{lender});

            var output = new Mock<IOutputStream>();
            output.Setup(x => x.Write(It.IsAny<QuoteResults>()))
                .Verifiable();

            var calcEngine = new Mock<ICalculator>();

            var args = new[] { "market.csv", 1000.ToString() };

            var calculationApp = new CalculateRateApp(
                reader.Object,
                output.Object,
                calcEngine.Object, 36);

            calculationApp.Run(args);

            output.Verify();
        }
    }
}
