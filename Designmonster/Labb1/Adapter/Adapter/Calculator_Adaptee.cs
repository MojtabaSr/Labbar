using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter
{
    public class Calculator_Adaptee
    {

        public double Result(double x, double y, string operation)
        {
            return operation.ToLower() switch
            {
                "a" => x + y,
                "s" => x - y,
                "m" => x * y,
                "d" => x / y,
                _ => throw new NotImplementedException(),
            };
        }
    }
}
