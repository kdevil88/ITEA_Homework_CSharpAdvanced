using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Calculator<T1, T2>
    {
        public double Add(T1 value1, T2 value2)
        {
            try
            {
                return Convert.ToDouble(value1) + Convert.ToDouble(value2);
            }
            catch
            {
                Console.WriteLine("Error while ADD {0} and {1}, but its concat result is '{2}'", value1.ToString(), value2.ToString(), value1.ToString() + value2.ToString());
                return 0;
            }
        }
        public double Substract(T1 value1, T2 value2)
        {
            try
            {
                return Convert.ToDouble(value1) - Convert.ToDouble(value2);
            }
            catch
            {
                Console.WriteLine("Error while SUBSTRACT {0} and {1}", value1.ToString(), value2.ToString());
                return 0;
            }
        }
        public double Multiply(T1 value1, T2 value2)
        {
            try
            {
                return Convert.ToDouble(value1) * Convert.ToDouble(value2);
            }
            catch
            {
                Console.WriteLine("Error while MULTIPLY {0} and {1}", value1.ToString(), value2.ToString());
                return 0;
            }
        }
        public double Divide(T1 value1, T2 value2)
        {
            try
            {
                return Convert.ToDouble(value1) / Convert.ToDouble(value2);
            }
            catch
            {
                Console.WriteLine("Error while DIVIDE {0} and {1}", value1.ToString(), value2.ToString());
                return 0;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Calculator<object, object> Calc = new Calculator<object, object>();
            string number1, number2, operation;
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
