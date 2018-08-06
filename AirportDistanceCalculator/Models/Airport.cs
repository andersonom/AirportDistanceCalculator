namespace AirportDistanceCalculator.Models
{
    public class Airport
    {
        public int Id { get; set; }
        public string Conuntry { get; set; }
        public string IATA { get; set; }
        public string CityIATA { get; set; }
        public string ConuntryIATA { get; set; }
        public string Name { get; set; }
        public Location  Location { get; set; }
    }
}
