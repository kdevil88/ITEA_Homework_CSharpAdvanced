using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime time = DateTime.Now;
            if (time == null)
            {
                /* Условие никогда не выполнится т.к. переменная типа DateTime не может принимать значение null */
            }

            DateTime? time2 = null;
            if (time2 == null)
            {
               Console.WriteLine(time2.HasValue);
                /* Применяя nullable тип - условие выполнится*/
            }
            Console.ReadKey();

        }
    }
}
