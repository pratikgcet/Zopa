using System;
using System.Collections.Generic;
using Quote;
using Quote.CalculationGrid;
using Quote.Readers;
using Quote.Writers;
using NUnit.Framework;
using Moq;

namespace UnitTestProject
{
    [TestFixture]
    public class ArgumentTest
    {
        
        [Test]
        public void GivenNullArguments_WhenRun_ThenThrowException()
        {
            var calc = new Mock<ICalculator>();
            var output = new Mock<IOutputStream>();
            var reader = new Mock<IReader>();
            const int length = 36;

            var calcApp = new CalculateRateApp(reader.Object, output.Object, calc.Object,length);
            Assert.Catch<ArgumentException>(() => calcApp.Run(null));
        }

        [Test]
        public void GivenLessArguments_WhenRun_ThenThrowException()
        {
            var calc = new Mock<ICalculator>();
            var output = new Mock<IOutputStream>();
            var reader = new Mock<IReader>();
            const int length = 36;

            var calcApp = new CalculateRateApp(reader.Object, output.Object, calc.Object, length);
            var args=new List<string>{"market.csv"};
            Assert.Catch<ArgumentException>(() => calcApp.Run(args));
        }

        [Test]
        public void WhenSecondInputIsNotInteger_ThrowArgumentNullException()
        {
            var calc = new Mock<ICalculator>();
            var output = new Mock<IOutputStream>();
            var reader = new Mock<IReader>();
            const int length = 36;

            var calcApp = new CalculateRateApp(reader.Object, output.Object, calc.Object, length);

            Assert.Throws<ArgumentNullException>(() => calcApp.Run(new List<string> {"market.csv", "String"}));
        }

        [Test]
        public void WhenAmountNotDivisbleByHundred_ThrowArgumentException()
        {
            var calc = new Mock<ICalculator>();
            var output = new Mock<IOutputStream>();
            var reader = new Mock<IReader>();
            const int length = 36;

            var calcApp = new CalculateRateApp(reader.Object, output.Object, calc.Object, length);
            var args = new List<string>{ "market.csv", "1111" };
            
            Assert.Catch<ArgumentException>(() => calcApp.Run(args));
        }

        [Test]
        public void WhenAmountIsLessThen1000_ThrowArgumentException()
        {
            var calc = new Mock<ICalculator>();
            var output = new Mock<IOutputStream>();
            var reader = new Mock<IReader>();
            const int length = 36;

            var calcApp = new CalculateRateApp(reader.Object, output.Object, calc.Object, length);
            var args = new List<string> { "market.csv", "999" };

            Assert.Catch<ArgumentException>(() => calcApp.Run(args));
        }

        [Test]
        public void WhenLoanAmountIsGreaterThen15000_ThrowArgumentException()
        {
            var calc = new Mock<ICalculator>();
            var output = new Mock<IOutputStream>();
            var reader = new Mock<IReader>();
            const int length = 36;

            var calcApp = new CalculateRateApp(reader.Object, output.Object, calc.Object, length);
            var args = new List<string> { "market.csv", "15001" };

            Assert.Catch<ArgumentException>(() => calcApp.Run(args));
        }

    }
}
