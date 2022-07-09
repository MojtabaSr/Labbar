using System;

//Detta är designmönster strategy

namespace Strategy
{
    internal class Program
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

           
            switch (operation)
            {
                case "a":
                    Calculator addition = new Calculator(new Addition());
                    Console.WriteLine($"The result is {addition.Calculate(firstVal, secondVal)}");
                    break;
                case "s":
                    Calculator subtraction = new Calculator(new Subtraction());
                    Console.WriteLine($"The result is {subtraction.Calculate(firstVal, secondVal)}");
                    break;
                case "m":
                    Calculator multiply = new Calculator(new Multiplication());
                    Console.WriteLine($"The result is {multiply.Calculate(firstVal, secondVal)}");
                    break;
                case "d":
                    Calculator divide = new Calculator(new Division());
                    Console.WriteLine($"The result is {divide.Calculate(firstVal, secondVal)}");
                    break;
            }
        }
    }
}
