using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortech_Assignment.Domain.Models
{
    public class Country
    {
        public string Cca2 { get; set; }
        public string Cca3 { get; set; }
        public string OfficialName { get; set; }        
        public string CommenName { get; set; }
        public string PostalCodeFormat { get; set; }    
        public float CapitalLatitude { get; set; }
        public float CapitalLongitude { get; set; }
    }
}



