using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            var @dictionary = new[]
            {
                new { Eng = "car", Rus = "машина"},
                new { Eng = "player", Rus = "игрок"},
                new { Eng = "language", Rus = "язык"},
                new { Eng = "lesson", Rus = "урок" },
                new { Eng = "client", Rus = "клиент"},
                new { Eng = "program", Rus = "программа"},
                new { Eng = "word", Rus = "слово"},
                new { Eng =  "teacher", Rus = "учитель"},
                new { Eng = "application", Rus = "приложение"},
                new { Eng = "student", Rus =  "студент"}   
            };
            Console.WriteLine("English-Russian dictionary");
            Console.WriteLine(new string ('=', 40));
            dynamic SortedDic = @dictionary.OrderBy(x => x.Eng);
            foreach (var item in SortedDic)
            {
                Console.WriteLine("||   {0} - {1}", item.Eng, item.Rus);
            }
            Console.WriteLine(new string ('=', 40));
            Console.ReadKey();
        }
    }
}
