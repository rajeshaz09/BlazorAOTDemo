using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BlazorMessagePack.Models
{
    [DataContract]
    public class WeatherForecast
    {
        [DataMember(Order = 0)]
        public DateTime Date { get; set; }

        [DataMember(Order = 1)]
        public int TemperatureC { get; set; }

        [DataMember(Order = 2)]
        public string Summary { get; set; }

        [DataMember(Order = 3)]
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
