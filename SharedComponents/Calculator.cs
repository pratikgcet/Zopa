using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents
{
    public class Calculator : ICalculator
    {

        public int Divide(int numerator, int denominator)
        {
            try
            {
                
                return numerator/denominator;
            }
            catch (DivideByZeroException exception)
            {

                throw new DivideByZeroException("denominator should be greater than 0",exception);
            }
            catch (FormatException e)
            {
                throw new FormatException("Incorrect Format", e);
            }
        }
    }
}
