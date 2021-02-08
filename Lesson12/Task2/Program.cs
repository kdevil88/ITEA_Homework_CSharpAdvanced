using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[2000000];
            Random rand = new Random();
            Parallel.For(0, arr.Length, (i) => arr[i] = rand.Next(arr.Length));
            var odds = arr.AsParallel().Where(i => i % 2 == 1);
            foreach (int odd in odds)
            {
                Console.WriteLine("Нечетное число = {0}", odd);
                Thread.Sleep(500);
            }
            Console.ReadKey();
        }
    }
}
