using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class SomeClass
    {
        [ObsoleteAttribute("better call method B", false)]
        public bool FieldA = true;
        public bool FieldB = false;
        [ObsoleteAttribute("better call method D", true)]
        public bool FieldC = true;
        public bool FieldD = false;
    }
    class Program
    {
        static void Main(string[] args)
        {
            SomeClass some = new SomeClass();
            bool b, d;
            b = some.FieldA & some.FieldB;
            Console.WriteLine("Result 1: {0}", b);
            d = some.FieldC & some.FieldD;
            Console.WriteLine("Result 2: {0}", d);
            Console.ReadKey();
        }
    }
}
