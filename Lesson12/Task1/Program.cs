using System;
using System.Threading;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, string> something = new Func<string, string>(DoSomething);
            something.BeginInvoke("\nThat's all, folks!", SomeCallback, something);
            Console.ReadKey();
        }

        static string DoSomething(string text)
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("||");
                Thread.Sleep(100);
            }
            for (int i = 0; i < 50; i++)
            {
                Console.Write("=");
                Thread.Sleep(50);
            }
            return text;
        }

        static void SomeCallback(IAsyncResult res)
        {
            Func<string, string> sender = res.AsyncState as Func<string, string>;
            Console.WriteLine(sender.EndInvoke(res));
        }
    }
}
