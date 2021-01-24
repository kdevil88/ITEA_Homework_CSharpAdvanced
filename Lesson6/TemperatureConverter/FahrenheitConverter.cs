using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureConverter
{
    public class FahrenheitConverter : TemperatureConverter
    {
        public FahrenheitConverter()
        {
            TempDef = "°F";
        }
        public override string HotOrCold(double Temperature)
        {
            if (Temperature <= 32)
                return "Cold";
            else if 
               (Temperature > 32 & Temperature <= 104)
                return "In the middle";
            else 
                return "Hot";
        }
        public override Double Convert(double value_in, TemperatureTypes DestinationType)
        {
            switch (DestinationType)
            {
                case TemperatureTypes.Celsius:
                    return (5.0 / 9.0) * (value_in - 32);
                case TemperatureTypes.Kelvin:
                    return (5.0 / 9.0) * (value_in + 459.67);
                default:
                    return value_in;
            }
        }
    }
}
