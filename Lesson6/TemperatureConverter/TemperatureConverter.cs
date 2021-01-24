using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureConverter
{
    public abstract class TemperatureConverter
    {
        protected string TempDef { get; set; }
        public string TempDefinition { get { return TempDef; } }
        public abstract string HotOrCold(double Temperature);
        public abstract Double Convert(double value_in, TemperatureTypes DestinationType);
    }
}
