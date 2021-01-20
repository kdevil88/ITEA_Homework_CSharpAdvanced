using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<Model1>());
            using (Model1 db = new Model1())
            {
                try
                {
                    BaseSource m1 = new BaseSource() { Id = 1, Name = "Database" };
                    BaseSource m2 = new BaseSource() { Id = 1, Name = "Code" };
                    db.BaseSourceList.AddRange(new List<BaseSource>() {m1, m2});
                    db.SaveChanges();

                    Console.WriteLine("To do develop a program you might have anything from this:");
                    foreach (var item in db.BaseSourceList)
                    {
                        Console.WriteLine("{0}. {1}", item.Id, item.Name);
                    }
                    Console.WriteLine(new string('-', 50));

                    db.ApproachesList.Add(new Approaches() { BasedOn = m1, Name = "Database First" });
                    db.ApproachesList.Add(new Approaches() { BasedOn = m1, Name = "Empty Model" });
                    db.ApproachesList.Add(new Approaches() { BasedOn = m2, Name = "Code First" });
                    db.ApproachesList.Add(new Approaches() { BasedOn = m2, Name = "Empty Code" });
                    db.SaveChanges();

                    Console.WriteLine("There a 4 basic approaches:");
                    foreach (var item in db.ApproachesList)
                    {
                        Console.WriteLine("To use '{0}' approach you need {1}", item.Name, item.BasedOn?.Name);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.ReadKey();
        }
    }
}
