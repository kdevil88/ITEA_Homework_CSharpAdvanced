using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter writer = File.CreateText("ticket.txt"))
            {
                StringBuilder ticket = new StringBuilder();
                ticket.Append("Чек из супер-магазина\n\n");
                ticket.Append("Дата покупки 01.02.2021\n\n");
                ticket.Append(string.Format("{0} – {1} грн.\n", "Товар1", 12.04));
                ticket.Append(string.Format("{0} – {1} грн.\n", "Товар2", 1.00));
                ticket.Append(string.Format("{0} – {1} грн.\n", "Товар3", 23.43));
                ticket.Append(string.Format("{0} – {1} грн.\n", "Товар4", 650.23));
                ticket.Append(string.Format("{0} – {1} грн.\n", "Товар5", 387.43));
                ticket.Append(string.Format("{0} – {1} грн.\n", "Товар6", 422.99));
                ticket.Append(string.Format("{0} – {1} грн.\n", "Товар7", 1545.13));
                ticket.Append(string.Format("{0} – {1} грн.\n", "Товар8", 35000.00));
                ticket.Append(string.Format("{0} – {1} грн.\n", "Товар9", 239.65));
                ticket.Append(string.Format("{0} – {1} грн.\n", "Товар10", 667.89));
                writer.WriteLine(ticket);
            }
            using (StreamReader reader = File.OpenText("ticket.txt"))
            {
                Console.WriteLine("Current culture: {0}\n", CultureInfo.CurrentCulture);
                Console.WriteLine(new string('-', 20));
                while (reader.Peek() != -1)
                {
                    Console.WriteLine(reader.ReadLine());
                }
                Console.WriteLine(new string('=', 50));
                reader.DiscardBufferedData();
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                CultureInfo.CurrentCulture = new CultureInfo("en-US");
                CultureInfo.CurrentUICulture = CultureInfo.CurrentCulture;
                Console.WriteLine("Current culture: {0}\n", CultureInfo.CurrentCulture);
                Console.WriteLine(new string('-', 20));
                while (reader.Peek() != -1)
                {
                    Console.WriteLine(reader.ReadLine(), CultureInfo.CurrentCulture.Name);
                }
            }
            Console.ReadKey();
        }
    }
}
