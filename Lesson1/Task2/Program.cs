using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class MyClass<T> where T : Device, new()
    {
        public T device = new T();
        public void GetDeviceInfo()
        {
            Console.WriteLine(device.GetDeviceInfo());
        }
    }
    class Device
    {
        protected int ScreenSize;
        protected int RAM;
        public virtual string GetDeviceInfo()
        {
            return "Device has no information";
        }
    }
    class PC : Device
    {
        private int MonitorCount;
        public void Describe(int AScreenSize, int ARAM, int AMonitorCount)
        {
            ScreenSize = AScreenSize;
            RAM = ARAM;
            MonitorCount = AMonitorCount;
        }
        public override string GetDeviceInfo()
        {
            return string.Format("This PC has {0} inches screen, {1} GB RAM and {2} monitors", ScreenSize, RAM, MonitorCount);
        }
    }
    class Laptop : Device
    {
        public void Describe(int AScreenSize, int ARAM)
        {
            ScreenSize = AScreenSize;
            RAM = ARAM;
        }
        public override string GetDeviceInfo()
        {
            return string.Format("This laptop has {0} inches screen and {1} GB RAM", ScreenSize, RAM);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // pc
            MyClass<PC> pc = new MyClass<PC>();
            pc.device.Describe(21, 32, 2);
            pc.GetDeviceInfo();
            // laptop 
            MyClass<Laptop> laptop = new MyClass<Laptop>();
            laptop.device.Describe(17, 8);       
            laptop.GetDeviceInfo();
            Console.ReadKey();
        }
    }
}
