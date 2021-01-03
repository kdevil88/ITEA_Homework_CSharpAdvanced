using System;

namespace Task2
{
    class Calculator2
    {
        public delegate double CalcAction(double num1, double num2);
        public CalcAction Add = (n1, n2) => { return n1 + n2; };
        public CalcAction Substract = (n1, n2) => { return n1 - n2; };
        public CalcAction Multiply = (n1, n2) => { return n1 * n2; };
        public CalcAction Divide = (n1, n2) => 
            { 
                try
                {
                    if (n2 == 0) 
                        throw new DivideByZeroException();
                    return n1 / n2;
                }
                catch (DivideByZeroException)
                {
                    return 0;
                }
            };
    }
    class Program
    {
        static void Main(string[] args)
        {
            Calculator2 Calc = new Calculator2();
            string operation;
            double number1, number2;
            while (true)
            {
                Console.Write("Enter first number: ");
                number1 = double.Parse(Console.ReadLine());
                Console.Write("Enter operation (+,-,*,/): ");
                operation = Console.ReadLine();
                Console.Write("Enter second number: ");
                number2 = double.Parse(Console.ReadLine());
                switch (operation)
                {
                    case "+":
                        Console.WriteLine("Answer is: {0}", Calc.Add(number1, number2));
                        break;
                    case "-":
                        Console.WriteLine("Answer is: {0}", Calc.Substract(number1, number2));
                        break;
                    case "*":
                        Console.WriteLine("Answer is: {0}", Calc.Multiply(number1, number2));
                        break;
                    case "/":
                        Console.WriteLine("Answer is: {0}", Calc.Divide(number1, number2));
                        break;
                    default:
                        Console.WriteLine("Operation not supported");
                        break;
                }

                Console.ReadKey();
            }
        }
    }
}
