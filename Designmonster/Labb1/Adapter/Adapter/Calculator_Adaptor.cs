using System;
using System.Collections.Generic;
using System.Text;

//Detta är designmönster Adapter

namespace Adapter
{
    public class Calculator_Adaptor : ICalculator
    {
        public double x;
        public double y;
        public string operation;
        Calculator_Adaptee calculateDisplay= new Calculator_Adaptee();

        public Calculator_Adaptor(double _x, double _y, string _operation)
        {
            x = _x;
            y = _y;
            operation = _operation;
        }


        public void DisplayResult()
        {
            Console.WriteLine($"The result is: {calculateDisplay.Result(x,y,operation)}");
        }
    }
}
