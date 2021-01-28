using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static string search_filename;
        static List<string> search_results;
        static void SearchDir(string Dir)
        {
            Console.WriteLine("Searching in dir: " + Dir);
            try
            {
                foreach (string dirname in Directory.GetDirectories(Dir))
                {
                    SearchFiles(dirname);
                    SearchDir(dirname);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(Dir + ": " + e.Message);
            }
        }
        static void SearchFiles(string Dirname)
        {
            try
            {
                foreach (string filename in Directory.GetFiles(Dirname))
                {
                    if (Path.GetFileName(filename).Contains(search_filename))
                        search_results.Add(filename);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(Dirname + ": " + e.Message);
            }
        }
        static void Main(string[] args)
        {
            // enter text to search
            search_results = new List<string>();
            while (string.IsNullOrWhiteSpace(search_filename))
            { 
                Console.WriteLine("Enter file name you want to search:");
                search_filename = Console.ReadLine();
            }
            // enter search locations
            Console.WriteLine("Enter where you want to search (or leave empty for global search):");
            string start_dir = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(start_dir))
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    SearchFiles(drive.RootDirectory.FullName);
                    SearchDir(drive.RootDirectory.FullName);
                }
            }
            else
            {
                SearchFiles(@start_dir);
                SearchDir(@start_dir);
            }
            // show search results
            Console.WriteLine("\nSearch results:");
            foreach (string res in search_results)
            {
                Console.WriteLine(search_results.IndexOf(res)+1 + ". " + res);
            }
            // make operations
            if (search_results.Count() == 0)
                Console.WriteLine("Sorry, no file found");
            else
            {
                Console.WriteLine("\nEnter name of operation you want to do with file:");
                Console.WriteLine("open");
                Console.WriteLine("archive");
                string Operation = Console.ReadLine();
                Console.WriteLine("\nEnter file number you want to deal with:");
                choose_filenum:
                int filenum = int.Parse(Console.ReadLine());
                if (filenum < 1 || filenum > search_results.Count())
                {
                    Console.WriteLine("No such file number");
                    goto choose_filenum;
                }
                switch (Operation)
                {
                    case "open":
                        using (StreamReader textfile = File.OpenText(search_results[filenum-1]))
                        {
                            Console.Clear();
                            Console.WriteLine(search_results[filenum - 1] + " contents:\n");
                            Console.WriteLine(textfile.ReadToEnd().Trim());
                        }
                        break;
                    case "archive":
                        try
                        {
                            byte[] source_bytes = File.ReadAllBytes(search_results[filenum-1]);
                            FileStream dest = File.Create(search_results[filenum-1] + ".zip");
                            using (GZipStream zip = new GZipStream(dest, CompressionLevel.Optimal))
                            {
                                zip.Write(source_bytes, 0, source_bytes.Length);
                            }
                            Console.WriteLine("'{0}' was created", Path.ChangeExtension(search_results[filenum-1], "zip"));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error while archiving file '{0}': {1}", search_results[filenum-1], e.Message);
                        }
                        break;
                    default:
                        Console.WriteLine("Operation not supported");
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
