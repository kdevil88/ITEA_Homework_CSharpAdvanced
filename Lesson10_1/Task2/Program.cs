using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Task2
{
    [Serializable]
    [XmlRoot]
    public class SportEvent
    {
        public SportEvent()
        {
            this.Teams = new List<string>();
        }
        [XmlAttribute]
        public string Sport;
        [XmlAttribute]
        public string Country;
        [XmlAttribute]
        public string Tournament;
        [XmlArray]
        public List<string> Teams;
        public string FullName
        {
            get { return string.Format("{0}. {1}. {2}. {3} - {4}", Country, Sport, Tournament, Teams[0], Teams[1]); }
        }
    }
    class Program
    {
        static readonly XmlSerializer xmlserializer = new XmlSerializer(typeof(SportEvent));
        static void Main(string[] args)
        {
            SportEvent @event = new SportEvent();
            @event.Country = "Ukraine";
            @event.Sport = "Football";
            @event.Tournament = "Premier Liga";
            @event.Teams.Add("Zorya(Lugansk)");
            @event.Teams.Add("Shakhter(Donetsk)");
            Console.WriteLine("Main event: {0}", @event.FullName);
            using (FileStream stream = new FileStream("SportEvent.xml", FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                xmlserializer.Serialize(stream, @event);
                Console.WriteLine("Class serialized via XML: SportEvent.xml");
            }
            Console.ReadKey();
        }
    }
}
