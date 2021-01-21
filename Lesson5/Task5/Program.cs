using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
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
                    Courses c1 = new Courses() { Name = "Python for dummies" };
                    Courses c2 = new Courses() { Name = "C# advanced" };
                    Courses c3 = new Courses() { Name = ".NET Core web development" };
                    db.CoursesList.AddRange(new List<Courses>() { c1, c2, c3 });
                    db.SaveChanges();

                    // orderby, count
                    Console.WriteLine("There a {0} courses:\n", db.CoursesList.Count());
                    foreach (var item in db.CoursesList.OrderBy(n => n.Name))
                    {
                        Console.WriteLine(item.Name);
                    }
                    Console.WriteLine(new string('-', 50));

                    db.CourseDetails.Add(new CourseDetail() { Course = c1, Duration = 10 });
                    db.CourseDetails.Add(new CourseDetail() { Course = c2, Duration = 12 });
                    db.CourseDetails.Add(new CourseDetail() { Course = c3, Duration = 14 });
                    db.SaveChanges();

                    // first
                    var first = db.CourseDetails.First(n => n.Course.Name.StartsWith("C#"));
                    Console.WriteLine("First found C# course: {0}", first?.Course.Name);
                    // firstordefault
                    var firstordefault = db.CourseDetails.FirstOrDefault(n => n.Course.Name.StartsWith("Delphi"));
                    Console.WriteLine("FirstOrDefault found Delphi course: {0}", 
                        firstordefault == null ? "не найдено" : firstordefault.Course.Name);
                    //min
                    int min = db.CourseDetails.Min(d => d.Duration);
                    Console.WriteLine("Shortest course duration: {0} hours", min);
                    //max
                    int max = db.CourseDetails.Max(d => d.Duration);
                    Console.WriteLine("Longest course duration: {0} hours", max);
                    //average
                    double avg = db.CourseDetails.Average(d => d.Duration);
                    Console.WriteLine("Average course duration: {0} hours", avg);
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
