using System;
using System.Collections.Generic;

namespace Task1
{
    class Book<T>
    {
        private string name;
        private T price;
        public string Name
        {
            get => name; set { name = value; }
        }
        public T Price
        {
            get => price; set { price = value; }
        }
        public void Show()
        {
            Console.WriteLine("{0} costs {1}", Name, Price);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<object> book_array = new List<object>();
            Book<int> book1 = new Book<int>() { Name = "Book#1", Price = 10 };
            Book<double> book2 = new Book<double>() { Name = "Book#2", Price = 10.55 };
            Book<string> book3 = new Book<string>() { Name = "Book#3", Price = "some price" };
            book_array.Add(book1);
            book_array.Add(book2);
            book_array.Add(book3);
            foreach (object book in book_array)
            {
                if (book is Book<int>)
                {
                    (book as Book<int>).Show();
                }
                else
                if (book is Book<double>)
                {
                    (book as Book<double>).Show();
                }
                else
                {
                    Console.WriteLine("Unsupported type");
                }
            }
            // Есть ли более красивый вариант использования классов с обобщенными типами в массивах?
            // Например, не проверяя тип вызывать какой-то метод (на нашем примере Show?)
            Console.ReadKey();
        }
    }
}