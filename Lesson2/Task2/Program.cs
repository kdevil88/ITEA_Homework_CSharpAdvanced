using System;
using Task1;

namespace Task2
{
    static class MyListExtension
    {
        public static T[] GetArray<T>(this MyList<T> list)
        {
            T[] array = new T[list.Count];
            for (int i = 0; i < list.Count; i++)
            {              
                array[i] = list[i];
            }
            return array;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> int_arr = new MyList<int>();
            for (int i = 0; i < 20; i++)
            {
                int_arr.Add(i + 1);
            }
            int[] array = int_arr.GetArray();
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i].ToString());
            }
            Console.ReadKey();
        }
    }
}
