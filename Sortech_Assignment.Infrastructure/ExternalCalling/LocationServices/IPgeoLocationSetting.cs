using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortech_Assignment.Infrastructure.ExternalCalling.IPgeoLocation
{
    public class IPgeoLocationSetting 
    {
        public const string Name = "Ipgeolocation";
        public string Key { get; set; }
        public string BaseUrl { get; set; }
    }
}
