using System;
using System.Collections.Generic;
using System.Text;

//här kör vi vårt factory

namespace Labb1.FactoryPattern
{
    public class CalculatorFactory
    {
        public ICalculator SelectCalculation(string operation)
        {
            return operation.ToLower() switch
            {
                "a" => new Addition(),
                "s" => new Subtraction(),
                "m" => new Multiplication(),
                "d" => new Division(),
                _ => throw new NotImplementedException()
            };
        }

    }



}
