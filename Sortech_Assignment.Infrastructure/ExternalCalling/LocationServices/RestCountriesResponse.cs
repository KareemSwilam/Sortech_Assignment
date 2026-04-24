using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortech_Assignment.Infrastructure.ExternalCalling.IPgeoLocation
{
    public class RestCountriesResponse: List<Class1>
    {
        
    }
    public class Class1
    {

        public string cca2 { get; set; }

        public string cca3 { get; set; }

        public Name name { get; set; }
        public Capitalinfo capitalInfo { get; set; }
        public Postalcode postalCode { get; set; }

    }
    public class Name
    {
        public string common { get; set; }
        public string official { get; set; }

    }
    public class Capitalinfo
    {
        public float[] latlng { get; set; }
    }
    public class Postalcode
    {
        public string format { get; set; }
        public string regex { get; set; }
    }
}




