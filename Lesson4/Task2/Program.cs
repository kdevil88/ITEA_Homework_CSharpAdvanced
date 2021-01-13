using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        class Car
        {
            public string Brand;
            public string Model;
            public int ProductionYear;
            public string Color;
        }
        class Customer
        {
            public string Name;
            public string Phone;
            public string Model;
        }
        static void Main(string[] args)
        {
            List<Car> Cars = new List<Car>
            {
                new Car
                {
                    Brand = "Tesla",
                    Model = "Model X",
                    ProductionYear = 2015,
                    Color = "Grey"
                },
                new Car
                {
                    Brand = "Zaz",
                    Model = "Gorbatiy",
                    ProductionYear = 1967,
                    Color = "Red"
                },
                new Car
                {
                    Brand = "Tesla",
                    Model = "Model X",
                    ProductionYear = 2015,
                    Color = "Blue"
                }
            };

            List<Customer> Customers = new List<Customer>
            {
                new Customer
                {
                    Name = "Petro",
                    Phone = "+38099999999",
                    Model = "Gorbatiy"
                }
            };

            var FullInfo = Customers.Join
                (Cars, c => c.Model, cs => cs.Model,
                (c, cs) => new { Name = c.Name, Phone = c.Phone, Brand = cs.Brand, Model = cs.Model, ProductionYear = cs.ProductionYear, Color = cs.Color });

            foreach (var item in FullInfo)
            {
                Console.WriteLine("Customer {0} (phone {1}) bought a new {2} {3} in {4} color {5} year released",
                    item.Name, item.Phone, item.Brand, item.Model, item.Color, item.ProductionYear);
            }
            Console.ReadKey();
        }
    }
}
