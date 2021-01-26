using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to create directories...");
            Console.ReadKey();
            List<DirectoryInfo> dirs = new List<DirectoryInfo>();
            for (int i = 0; i < 50; i++)
            {
                DirectoryInfo dir = new DirectoryInfo(@"Folder_" + i.ToString());
                dirs.Add(dir);
                if (dir.Exists)
                    Console.WriteLine("Directory '{0}' already exists", dir.FullName);
                else
                    try
                    { 
                        dir.Create();
                        dir.Refresh();
                        Console.WriteLine("Directory '{0}' created", dir.FullName);
                    }
                    catch (Exception e)
                    { 
                        Console.WriteLine("Error while creating directory '{0}': {1}", dir.FullName, e.Message);
                    }
            }

            Console.WriteLine("\nPress any key to get directories info...");
            Console.ReadKey();
            Console.Clear();
            foreach (DirectoryInfo dir in dirs)
            {
                if (dir.Exists)
                {
                    Console.WriteLine(new string('-', 50));
                    Console.WriteLine("FullName      : {0}", dir.FullName);
                    Console.WriteLine("Name          : {0}", dir.Name);
                    Console.WriteLine("Parent        : {0}", dir.Parent);
                    Console.WriteLine("CreationTime  : {0}", dir.CreationTime);
                    Console.WriteLine("Attributes    : {0}", dir.Attributes.ToString());
                    Console.WriteLine("Root          : {0}", dir.Root);
                    Console.WriteLine("LastAccessTime: {0}", dir.LastAccessTime);
                    Console.WriteLine("LastWriteTime : {0}", dir.LastWriteTime);
                }
                else
                {
                    Console.WriteLine("Directory {0} doesn't exists", dir.FullName);
                }
            }

            Console.WriteLine("\nPress any key to delete directories...");
            Console.ReadKey();
            Console.Clear();
            foreach (DirectoryInfo dir in dirs)
            {
                try
                {
                    dir.Delete();
                    Console.WriteLine("Directory '{0}' deleted", dir.FullName);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error while deleting directory '{0}': {1}", dir.FullName, e.Message);
                }
            }

            Console.ReadKey();
        }
    }
}
