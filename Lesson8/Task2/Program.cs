using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream stream = new FileStream("TelephoneBook.xml", FileMode.Open);
            stream.Position = 0;
            XmlTextReader xml = new XmlTextReader(stream);
            Console.WriteLine("XML file info:\n");
            while (xml.Read())
            {
                Console.WriteLine("{0,-15} {1,-15} {2,-15}",
                    xml.NodeType,
                    xml.Name, 
                    xml.Value);
            }
            Console.ReadKey();
        }
    }
}
