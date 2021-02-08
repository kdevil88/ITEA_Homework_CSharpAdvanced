using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Factory.StartNew(() => Parallel.Invoke(new ParallelOptions(), Parallel1, Parallel2));
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("MAIN ");
                Thread.Sleep(1000);
            }
        }

        static void Parallel1()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("FIRST_Parallel ");
                Thread.Sleep(1000);
            }
        }
        static void Parallel2()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("SECOND_Parallel ");
                Thread.Sleep(1000);
            }
        }
    }
}
