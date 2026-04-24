namespace Sortech_Assignment.Infrastructure.ExternalCalling.LocationServices
{
    public class IPgeoLocationResponse
    {
        public string ip { get; set; }
        public Location location { get; set; }

    }
    public class Location
    {

        public string country_code2 { get; set; }
        public string country_code3 { get; set; }
        public string country_name { get; set; }
        public string country_name_official { get; set; }
        public string country_capital { get; set; }

    }
}







