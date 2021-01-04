using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        delegate int RandomDelegate(Random rand);
        delegate double RandomAvgDelegate(RandomDelegate[] array);
        static void Main(string[] args)
        {
            RandomDelegate RandomFunc = (Random rand) => { return rand.Next(0, 100); };
            RandomAvgDelegate GetRandomAvg = (RandomDelegate[] arr) =>
            {
                double sum = 0;
                Random rand = new Random();
                for (int i = 0; i < arr.Length; i++)
                {
                    int r = arr[i](rand);
                    Console.WriteLine("{0} delegate returns = {1}", i + 1, r);
                    sum += r;
                }
                return sum / arr.Length;
            };
            RandomDelegate[] delegate_arr = new RandomDelegate[3];
            delegate_arr[0] = RandomFunc;
            delegate_arr[1] = RandomFunc;
            delegate_arr[2] = RandomFunc;
            Console.WriteLine("Average value is {0}", GetRandomAvg(delegate_arr));
            Console.ReadKey();
        }
    }
}
