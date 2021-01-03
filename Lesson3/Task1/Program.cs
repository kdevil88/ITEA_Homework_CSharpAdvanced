using System;

namespace Task1
{
    class Program
    {
        delegate int SomeDelegate(int a, int b, int c);
        static void Main(string[] args)
        {
            SomeDelegate avg_calc = delegate(int val1, int val2, int val3) { return (val1 + val2 + val3) / 3; };
            int res = avg_calc(5, 50, 500);
            Console.WriteLine("{0} result is {1}", avg_calc, res);
            Console.ReadKey();
        }
    }
}
