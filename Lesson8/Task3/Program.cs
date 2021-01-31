using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            XPathDocument doc = new XPathDocument("TelephoneBook.xml");
            XPathNavigator navi = doc.CreateNavigator();
            XPathNodeIterator phones = navi.Select("MyContacts/Contact/@TelephoneNumber");
            Console.WriteLine("XML document contains next phones:\n");
            foreach (XPathItem phone in phones)
            {
                Console.WriteLine(phone.Value);
            }
            Console.ReadKey();
        }
    }
}
