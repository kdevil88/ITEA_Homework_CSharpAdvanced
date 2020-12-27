using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    interface IMyList<T>
    {
        void Add(T item);
        T this[int index] { get; }
        int Count { get; }
        void Clear();
        bool Contains(T item);
    }
   class MyList<T>: IMyList<T>
    {
        private T[] array = new T[0];
        public MyList()
        {
            
            for (int i = 0; i < 20; i++)
            {
                this.Add((T)(object)(i+1));
            }
        }
        public void Add(T item)
        {
            Array.Resize(ref this.array, this.array.Length + 1);
            this.array[this.array.Length - 1] = item;
        }
        public T this[int index]
        {
            get { return array[index]; }
        }
        public int Count
        {
            get { return this.array.Length; }
        }
        public void Clear() 
        {
            for (int i = 0; i < this.Count; i++)
            {
                this.array[i] = default(T);
            }
            Array.Resize(ref this.array, 0);
        }
        public bool Contains(T item) 
        {
            return this.array.Contains<T>(item);
        }
        public void GetValues()
        {
            for (int i = 0; i < this.Count; i++)
            {
                Console.WriteLine(this.array[i].ToString());
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> int_arr = new MyList<int>();
            Console.WriteLine("Array elements are:");
            int_arr.GetValues();
            Console.WriteLine(new string('-', 10));
            Console.WriteLine("-1 contains in array: " + int_arr.Contains(-1).ToString());
            Console.WriteLine("1 contains in array: " + int_arr.Contains(1).ToString());
            Console.WriteLine(new string('-', 10));
            Console.WriteLine("After clear array elements are:");
            int_arr.Clear();
            int_arr.GetValues();
            Console.ReadKey();
        }
    }
}
