using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureConverter
{
    public class KelvinConverter : TemperatureConverter
    {
        public KelvinConverter()
        {
            TempDef = "K";
        }
        public override string HotOrCold(double Temperature)
        {
            if (Temperature <= 273.15)
                return "Cold";
            else if
               (Temperature > 273.15 & Temperature <= 313.15)
                return "In the middle";
            else
                return "Hot";
        }
        public override Double Convert(double value_in, TemperatureTypes DestinationType)
        {
            switch (DestinationType)
            {
                case TemperatureTypes.Celsius:
                    return value_in - 273.15;
                case TemperatureTypes.Fahrenheit:
                    return value_in * (9.0 / 5.0) - 459.67;
                default:
                    return value_in;
            }
        }
    }
}
