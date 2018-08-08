using Newtonsoft.Json;

namespace AirportDistanceCalculator.Models
{
    public class Airport
    {
        public string Country { get; set; }
        public string IATA { get; set; }
        public string City { get; set; }
        [JsonProperty("city_iata")]
        public string CityIATA { get; set; }
        [JsonProperty("country_iata")]
        public string CountryIATA { get; set; }
        public string Name { get; set; }
        public Location  Location { get; set; }
    }
}
