using System;

namespace Adapter
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Refer to the below menu for supported operations\n");
            Console.WriteLine("Addition: a\nSubtraction: s\nDivision: d\nMultiplication: m\n");
            string operation = Console.ReadLine();

            Console.WriteLine("Enter first value");
            double firstVal = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter second value");
            double secondVal = Convert.ToDouble(Console.ReadLine());

            ICalculator calculator=new Calculator_Adaptor(firstVal,secondVal,operation);
            calculator.DisplayResult();
            Console.ReadLine();

        }
    }
}
