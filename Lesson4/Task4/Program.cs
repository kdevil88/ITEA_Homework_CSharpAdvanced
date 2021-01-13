using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        class Client
        {
            public int Code;
            public int Year;
            public int Month;
            public int ActivityDuration;
        }
        static void Main(string[] args)
        {
            List<Client> clients = new List<Client>
            {
                new Client
                {
                    Code = 111,
                    Year = 2018,
                    Month = 12,
                    ActivityDuration = 43
                },
                new Client
                {
                    Code = 222,
                    Year = 2019,
                    Month = 6,
                    ActivityDuration = 3
                },
                new Client
                {
                    Code = 333,
                    Year = 2020,
                    Month = 2,
                    ActivityDuration = 32
                },
                new Client
                {
                    Code = 444,
                    Year = 2021,
                    Month = 11,
                    ActivityDuration = 555
                }
            };

            var SortedClients = clients.OrderBy(x => x.ActivityDuration);
            var LazyClient = SortedClients?.First();
            Console.WriteLine("Laziest client:");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Code {0}| Year {1}| Month {2}| ActivityDuration {3}", LazyClient.Code, LazyClient.Year, LazyClient.Month, LazyClient.ActivityDuration);
            Console.WriteLine(new string('-', 40));
            Console.ReadKey();
        }
    }
}
