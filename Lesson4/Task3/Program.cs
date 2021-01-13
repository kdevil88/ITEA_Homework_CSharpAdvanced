using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            IEnumerable<int> RandomRange = Enumerable.Range(1, 30).Select(x => rand.Next(-100, 100)).ToList();

            var positive = RandomRange.Where(x => x > 0);
            Console.WriteLine("Первый положительный элемент: {0}", positive?.First());
            var negative = RandomRange.Where(x => x < 0);
            Console.WriteLine("Последний негативный элемент: {0}", negative?.Last());

            Console.WriteLine(new string('-', 10));
            foreach (int num in RandomRange)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine(new string('-', 10));

            Console.ReadKey();
        }
    }
}
