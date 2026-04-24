using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortech_Assignment.Domain.Models
{
    public class Log
    {
        public string IPAddress { get; set; }   
        public DateTime Timestamp { get; set; }
        public string CountryCode { get; set; }
        public bool BlockedStatus { get; set; }
        public string UserAgent { get; set; }   
    }
}
