using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy
{
    public class Calculator
    {
        private ICalculator calculatorInterface;

        public Calculator(ICalculator operation)
        {
            calculatorInterface = operation;
        }
        public double Calculate(double x, double y)
        {
            return calculatorInterface.Calculate(x, y);
        }

    }
}
