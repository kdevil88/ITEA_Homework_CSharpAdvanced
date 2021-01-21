using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
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
                    Students s1 = new Students() { FIO = "Andrey Andreeev" };
                    Students s2 = new Students() { FIO = "Viktor Federovich" };
                    Students s3 = new Students() { FIO = "Petr Petrovich" };
                    Students s4 = new Students() { FIO = "Vladimir Aleksandrovich" };
                    db.StudentsList.AddRange(new List<Students>() { s1, s2, s3, s4 });
                    db.SaveChanges();

                    db.Groups.Add(new Group() { GroupId = 1, Student = s1 });
                    db.Groups.Add(new Group() { GroupId = 2, Student = s2 });
                    db.Groups.Add(new Group() { GroupId = 2, Student = s3 });
                    db.Groups.Add(new Group() { GroupId = 3, Student = s4 });
                    db.SaveChanges();

                    // include, select
                    var groups = db.Groups.Include(g => g.Student).Select(v => new { v.GroupId, StudentFIO = v.Student.FIO });
                    foreach (var item in groups)
                    {
                        Console.WriteLine("{0} is in group {1}", item.StudentFIO, item.GroupId);
                    }
                    Console.WriteLine(new string('-', 50));
                    // find
                    var student = db.Groups.Find(s4.Id);
                    if (student != null)
                        Console.WriteLine("Special student {0} found in group {1}", student.Student.FIO, student.GroupId);
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
