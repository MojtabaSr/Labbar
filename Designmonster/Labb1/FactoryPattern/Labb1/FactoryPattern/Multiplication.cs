using System;
using System.Collections.Generic;
using System.Text;

namespace Labb1.FactoryPattern
{
    public class Multiplication: ICalculator
    {
        public double GetResult(double x, double y)
        {
            return x * y;
        }
    }
}
