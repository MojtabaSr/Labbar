using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy
{
    public class Division : ICalculator
    {
        public double Calculate(double x, double y)
        {
            return x / y;
        }
    }
}
