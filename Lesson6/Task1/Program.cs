using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureConverter;

namespace Task1
{
    class Program
    {

        static void Main(string[] args)
        {
            FahrenheitConverter f_conv = new FahrenheitConverter();
            CelsiusConverter c_conv = new CelsiusConverter();
            KelvinConverter k_conv = new KelvinConverter();
            double temp;
            TemperatureTypes from, to;
            Console.WriteLine("1. {0}", f_conv.TempDefinition);
            Console.WriteLine("2. {0}", c_conv.TempDefinition);
            Console.WriteLine("3. {0}", k_conv.TempDefinition);
            while (true)
            {
                Console.Write("\nEnter temperature value: ");
                temp = double.Parse(Console.ReadLine());
                Console.Write("Enter source temperation type: ");
                from = (TemperatureTypes)int.Parse(Console.ReadLine());
                Console.Write("Enter destination temperation type: ");
                to = (TemperatureTypes)int.Parse(Console.ReadLine());
                switch (from)
                {
                    case TemperatureTypes.Fahrenheit:
                        switch (to)
                        {
                            case TemperatureTypes.Fahrenheit:
                                Console.WriteLine("{0}{1} is a {2}{3}", temp, f_conv.TempDefinition, f_conv.Convert(temp, to), f_conv.TempDefinition);
                                break;
                            case TemperatureTypes.Celsius:
                                Console.WriteLine("{0}{1} is a {2}{3}", temp, f_conv.TempDefinition, f_conv.Convert(temp, to), c_conv.TempDefinition);
                                break;
                            case TemperatureTypes.Kelvin:
                                Console.WriteLine("{0}{1} is a {2}{3}", temp, f_conv.TempDefinition, f_conv.Convert(temp, to), k_conv.TempDefinition);
                                break;
                            default:
                                break;
                        }
                        break;
                    case TemperatureTypes.Celsius:
                        switch (to)
                        {
                            case TemperatureTypes.Fahrenheit:
                                Console.WriteLine("{0}{1} is a {2}{3}", temp, c_conv.TempDefinition, c_conv.Convert(temp, to), f_conv.TempDefinition);
                                break;
                            case TemperatureTypes.Celsius:
                                Console.WriteLine("{0}{1} is a {2}{3}", temp, c_conv.TempDefinition, c_conv.Convert(temp, to), c_conv.TempDefinition);
                                break;
                            case TemperatureTypes.Kelvin:
                                Console.WriteLine("{0}{1} is a {2}{3}", temp, c_conv.TempDefinition, c_conv.Convert(temp, to), k_conv.TempDefinition);
                                break;
                            default:
                                break;
                        }
                        break;
                    case TemperatureTypes.Kelvin:
                        switch (to)
                        {
                            case TemperatureTypes.Fahrenheit:
                                Console.WriteLine("{0}{1} is a {2}{3}", temp, k_conv.TempDefinition, k_conv.Convert(temp, to), f_conv.TempDefinition);
                                break;
                            case TemperatureTypes.Celsius:
                                Console.WriteLine("{0}{1} is a {2}{3}", temp, k_conv.TempDefinition, k_conv.Convert(temp, to), c_conv.TempDefinition);
                                break;
                            case TemperatureTypes.Kelvin:
                                Console.WriteLine("{0}{1} is a {2}{3}", temp, k_conv.TempDefinition, k_conv.Convert(temp, to), k_conv.TempDefinition);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }

                Console.ReadKey();
            }
        }
    }
}
