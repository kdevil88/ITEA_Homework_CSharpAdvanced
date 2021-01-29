using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Task1
{
    class Program
    {
        static XmlDocument xmldoc;
        static XmlElement CreateContact(string name, string phone)
        {
            XmlElement contact = xmldoc.CreateElement("Contact");
            contact.InnerText = name;
            contact.SetAttribute("TelephoneNumber", phone);
            return contact;
        }
        static void Main(string[] args)
        {
            xmldoc = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmldoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = xmldoc.DocumentElement;
            xmldoc.InsertBefore(xmlDeclaration, root);
            XmlElement xmlroot = xmldoc.CreateElement("MyContacts");
            xmlroot.AppendChild(CreateContact("Alex", "09977776523"));
            xmlroot.AppendChild(CreateContact("Petr", "06832467236"));
            xmlroot.AppendChild(CreateContact("Vova", "06398784358"));
            xmldoc.AppendChild(xmlroot);
            xmldoc.Save("TelephoneBook.xml");
            Console.WriteLine("XML created with contents:\n");
            Console.WriteLine(System.Xml.Linq.XDocument.Parse(xmldoc.InnerXml).ToString());
            Console.ReadKey();
        }
    }
}
