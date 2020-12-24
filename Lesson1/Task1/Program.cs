using System;
using System.Collections.Generic;

namespace Task1
{
    class PBook
    {
        public virtual void Show() 
        {
            Console.WriteLine("Unsupported type");
        }
    }
    class Book<T>: PBook
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
        public override void Show()
        {
            Console.WriteLine("{0} costs {1}", Name, Price);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<PBook> book_array = new List<PBook>();
            Book<int> book1 = new Book<int>() { Name = "Book#1", Price = 10 };
            Book<double> book2 = new Book<double>() { Name = "Book#2", Price = 10.55 };
            Book<string> book3 = new Book<string>() { Name = "Book#3", Price = "some price" };
            book_array.Add(book1);
            book_array.Add(book2);
            book_array.Add(book3);
            foreach (PBook book in book_array)
            {
                book.Show();
            }
            Console.ReadKey();
        }
    }
}