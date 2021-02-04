using System;
using System.IO;
using System.Xml.Serialization;
using Task2;

namespace Task3
{
    class Program
    {
        static readonly XmlSerializer xmlserializer = new XmlSerializer(typeof(SportEvent));
        static void Main(string[] args)
        {
            using (FileStream stream = new FileStream("SportEvent.xml", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                SportEvent @event = xmlserializer.Deserialize(stream) as SportEvent;
                Console.WriteLine("Class deserialized via XML: SportEvent.xml");
                Console.WriteLine("Event: {0}", @event.FullName);
            }
            Console.ReadKey();
        }
    }
}
