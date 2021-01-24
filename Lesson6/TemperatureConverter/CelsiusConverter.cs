using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureConverter
{
    public class CelsiusConverter : TemperatureConverter
    {
        public CelsiusConverter()
        {
            TempDef = "°C";
        }
        public override string HotOrCold(double Temperature)
        {
            if (Temperature <= 0)
                return "Cold";
            else if
               (Temperature > 0 & Temperature <= 40)
                return "In the middle";
            else
                return "Hot";
        }
        public override Double Convert(double value_in, TemperatureTypes DestinationType)
        {
            switch (DestinationType)
            {
                case TemperatureTypes.Kelvin:
                    return value_in + 273.15;
                case TemperatureTypes.Fahrenheit:
                    return value_in * (9.0 / 5.0) + 32;
                default:
                    return value_in;
            }
        }
    }
}
