using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
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
                    Teachers t1 = new Teachers() { FIO = "Alex Glembitskij", Age = 27};
                    Teachers t2 = new Teachers() { FIO = "Elon Musk", Age = 49 };
                    db.TeachersList.AddRange(new List<Teachers>() { t1, t2 });
                    db.SaveChanges();

                    Console.WriteLine("In our Academy we have {0} teachers:", db.TeachersList.Count());
                    foreach (var item in db.TeachersList)
                    {
                        Console.WriteLine("{0}. {1}", item.Id, item.FIO);
                    }

                    Students s1 = new Students() { FIO = "Andrey Andreeev" };
                    Students s2 = new Students() { FIO = "Viktor Federovich" };
                    Students s3 = new Students() { FIO = "Petr Petrovich" };
                    Students s4 = new Students() { FIO = "Vladimir Aleksandrovich" };
                    db.StudentsList.AddRange(new List<Students>() { s1, s2, s3, s4 });
                    db.SaveChanges();

                    Console.WriteLine("\nbest students:");
                    foreach (var item in db.StudentsList)
                    {
                        Console.WriteLine("{0}. {1}", item.Id, item.FIO);
                    }

                    Courses c1 = new Courses() { Name = "C# Advanced" };
                    Courses c2 = new Courses() { Name = "How to create hyperloop" };
                    db.CoursesList.AddRange(new List<Courses>() { c1, c2 });
                    db.SaveChanges();

                    Console.WriteLine("\nand interesting courses:");
                    foreach (var item in db.CoursesList)
                    {
                        Console.WriteLine("{0}. {1}", item.Id, item.Name);
                    }

                    db.GroupsList.Add(new Groups() { Course = c1, Teacher = t1, Student = s1 });
                    db.GroupsList.Add(new Groups() { Course = c1, Teacher = t1, Student = s2 });
                    db.GroupsList.Add(new Groups() { Course = c1, Teacher = t1, Student = s3 });
                    db.GroupsList.Add(new Groups() { Course = c2, Teacher = t2, Student = s4 });
                    db.SaveChanges();

                    Console.WriteLine(new string('-', 50));

                    Console.WriteLine("Our groups be like:");
                    foreach (var item in db.GroupsList)
                    {
                        Console.WriteLine("{0} - {1} - {2}", item.Course.Name, item.Teacher.FIO, item.Student.FIO);
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
