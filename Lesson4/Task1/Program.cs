using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Calculator3
    {
        public delegate dynamic CalcAction(dynamic num1, dynamic num2);
        public CalcAction Add = (n1, n2) => 
        {
            try
            {
                return Convert.ToDouble(n1) + Convert.ToDouble(n2);
            }
            catch (Exception)
            {
                return 0;
            }
        };
        public CalcAction Substract = (n1, n2) =>
        {
            try
            {
                return Convert.ToDouble(n1) - Convert.ToDouble(n2);
            }
            catch (Exception)
            {
                return 0;
            }
        };
        public CalcAction Multiply = (n1, n2) =>
        {
            try
            {
                return Convert.ToDouble(n1) * Convert.ToDouble(n2);
            }
            catch (Exception)
            {
                return 0;
            }
        };
        public CalcAction Divide = (n1, n2) =>
        {
            try
            {
                return Convert.ToDouble(n1) / Convert.ToDouble(n2);
            }
            catch (Exception)
            {
                return 0;
            }
        };
    }
    class Program
    {
        static void Main(string[] args)
        {
            Calculator3 Calc = new Calculator3();
            string operation;
            dynamic number1, number2;
            while (true)
            {
                Console.Write("Enter first number: ");
                number1 = Console.ReadLine();
                Console.Write("Enter operation (+,-,*,/): ");
                operation = Console.ReadLine();
                Console.Write("Enter second number: ");
                number2 = Console.ReadLine();
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
