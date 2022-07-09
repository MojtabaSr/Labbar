using Labb1.FactoryPattern;
using System;

//Detta är designmönster factorypattern

namespace Labb1
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Refer to the below menu for supported operations\n");
            Console.WriteLine("Addition: a\nSubtraction: s\nDivision: d\nMultiplication: m\n");
            string operation= Console.ReadLine();

            Console.WriteLine("Enter first value");
            double firstVal = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter second value");
            double secondVal = Convert.ToDouble(Console.ReadLine());

            CalculatorFactory calcFactory = new CalculatorFactory();
            Console.WriteLine($"The result is: {calcFactory.SelectCalculation(operation).GetResult(firstVal, secondVal)}");
            Console.ReadLine();
        }
    }
}
