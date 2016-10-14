using System;
using NUnit.Framework;
using SharedComponents;

namespace UnitTestProject
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void GivenTwoInputs_WhenDivide_NoError()
        {
            var calc=new Calculator();
            var res = calc.Divide(10, 10);
            Assert.AreEqual(1,res);
        }

        [Test]
        public void GivenTwoInputs_WhenDivideByZero_Exception()
        {
            var calc = new Calculator();
            
            Assert.That(()=>calc.Divide(10, 0),Throws.TypeOf<DivideByZeroException>());
        }
    }
}
