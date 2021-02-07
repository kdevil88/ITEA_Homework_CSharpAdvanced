using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int method_num = 0;

            RecursionMethod();

            void RecursionMethod()
            {
                Console.WriteLine("Вызов метода в {0}-й раз, в потоке {1}", ++method_num, Thread.CurrentThread.GetHashCode());
                Thread.Sleep(1000);
                Thread recurs = new Thread(RecursionMethod);
                recurs.Start();
            }
        }
    }
}
