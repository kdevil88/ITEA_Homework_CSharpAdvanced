using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool login_accepted = false;
            bool pass_accepted = false;
            Console.WriteLine("Please register!\n");
            while (!login_accepted)
            {
                Console.WriteLine("Enter your login: ");
                string login = Console.ReadLine();
                Regex login_regex = new Regex(@"^[a-zA-Z]+$");
                login_accepted = login_regex.IsMatch(login);
                if (!login_accepted)
                    Console.WriteLine("Error! Login must contain latin-alphabet characters only");
            }
            while (!pass_accepted)
            {
                Console.WriteLine("\nEnter your password: ");
                string pass = Console.ReadLine();
                Regex pass_regex = new Regex(@"^[A-Za-z]+\d+.*$");
                pass_accepted = pass_regex.IsMatch(pass);
                if (!pass_accepted)
                    Console.WriteLine("Error! Password must contain digits and characters");
            }
            Console.WriteLine("\nYou successfully registered!");
            Console.ReadKey();

        }
    }
}
