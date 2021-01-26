using System;
using System.Collections.Generic;
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
            // create and write
            try
            {
                using (StreamWriter textfile = File.CreateText("Task2.txt"))
                {
                    Console.WriteLine("File created...");
                    Console.WriteLine("\nEnter text to write in file:");
                    string text = Console.ReadLine();
                    textfile.WriteLine(text);
                    Console.WriteLine("\nText saved to file...");
                }
                Console.WriteLine("\nFile closed...");
            }
            catch (Exception e)
            {
                Console.WriteLine("\nError while creating file: {0}", e.Message);
            }
            // open and read
            try
            {
                using (StreamReader textfile = File.OpenText("Task2.txt"))
                {
                    Console.WriteLine("File opened...");
                    Console.WriteLine("\nFile contains:");
                    Console.WriteLine(textfile.ReadToEnd().Trim());
                }
                Console.WriteLine("\nFile closed...");
            }
            catch (Exception e)
            {
                Console.WriteLine("\nError while opening file: {0}", e.Message);
            }
            Console.ReadKey();
        }
    }
}
