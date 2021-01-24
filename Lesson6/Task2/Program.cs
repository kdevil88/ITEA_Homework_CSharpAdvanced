using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly_tempconvert = null;

            try
            {
                assembly_tempconvert = Assembly.Load("TemperatureConverter");
                Type CelsiusConverterType = assembly_tempconvert.GetType("TemperatureConverter.CelsiusConverter");
                object CelsiusConverterInstance = Activator.CreateInstance(CelsiusConverterType);
                // get methods
                MethodInfo CelsiusConvert = CelsiusConverterType.GetMethod("Convert");
                MethodInfo CelsiusHotOrCold = CelsiusConverterType.GetMethod("HotOrCold");
                // get prop
                PropertyInfo TempDefinition = CelsiusConverterType.GetProperty("TempDefinition");
                // get enum
                Type TemperatureTypes = assembly_tempconvert.GetType("TemperatureConverter.TemperatureTypes");
                object TemperatureTypesInst = Activator.CreateInstance(TemperatureTypes);

                Console.Write("Enter celsius temperature: ");
                double temp = double.Parse(Console.ReadLine());
                Console.WriteLine("{0}{1} is {2} and equals {3}°F", temp, TempDefinition.GetValue(CelsiusConverterInstance),
                    CelsiusHotOrCold.Invoke(CelsiusConverterInstance, new object[] { temp }),
                    CelsiusConvert.Invoke(CelsiusConverterInstance, new object[] { temp, TemperatureTypes.GetField("Fahrenheit").GetValue(TemperatureTypesInst) }));
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
