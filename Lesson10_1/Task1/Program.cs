using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;

namespace Task1
{
    [Serializable]
    public class CurrentInfo
    {
        public CurrentInfo()
        {
            CurrentDateTime = DateTime.Now;
        }
        public int TemperatureOutside;
        public DateTime CurrentDateTime;
        public string Day;
    }
    class Program
    {
        static readonly XmlSerializer xmlserializer = new XmlSerializer(typeof(CurrentInfo));
        static void Main(string[] args)
        {
            CurrentInfo info = new CurrentInfo();
            info.Day = "wednesday";
            info.TemperatureOutside = -3;
            Console.WriteLine("Current date and time: {0}", info.CurrentDateTime);
            Console.WriteLine("Current day of week: {0}", info.Day);
            Console.WriteLine("Current temperature outside: {0}", info.TemperatureOutside);
            Console.WriteLine(new string('=', 50));
            // xml
            using (FileStream stream = new FileStream("CurrentInfo.xml", FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                xmlserializer.Serialize(stream, info);
                Console.WriteLine("Class serialized via XML: CurrentInfo.xml");
            }
            // binary
            using (FileStream stream = File.Create("CurrentInfo.bin"))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, info);
                Console.WriteLine("Class serialized via Binary: CurrentInfo.bin");
            }
            // SOAP
            using (FileStream stream = File.Create("CurrentInfoSOAP.xml"))
            {
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(stream, info);
                Console.WriteLine("Class serialized via Binary: CurrentInfoSOAP.xml");
            }
            Console.ReadKey();
        }
    }
}
