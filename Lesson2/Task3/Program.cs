using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    static class SortedListExtension
    {
        public static void ShowValues(this IEnumerable<KeyValuePair<int, string>> sortedlist)
        {
            foreach (KeyValuePair<int, string> item in sortedlist)
            {
                Console.WriteLine("Theme of the {0} lesson - {1}", item.Key, item.Value);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SortedList<int, string> Lessons = new SortedList<int, string>();
            Console.WriteLine("Default values:");
            Lessons.Add(1, "Generics");
            Lessons.Add(2, "Collections");
            Lessons.Add(3, "Something new");
            Lessons.ShowValues();
            Console.WriteLine(new string('-', 10));
            Console.WriteLine("Ordered values:");
            var Lessons_Ordered = Lessons.OrderBy(kp => kp.Value);
            Lessons_Ordered.ShowValues();
            Console.WriteLine(new string('-', 10));
            Console.WriteLine("Ordered desc values:");
            var Lessons_Ordered_desc = Lessons.OrderByDescending(kp => kp.Value);
            Lessons_Ordered_desc.ShowValues();
            Console.WriteLine(new string('-', 10));
            Console.WriteLine("Reversed values:");
            var Lessons_Reversed = Lessons.Reverse();
            Lessons_Reversed.ShowValues();
            Console.ReadKey();
        }
    }
}
