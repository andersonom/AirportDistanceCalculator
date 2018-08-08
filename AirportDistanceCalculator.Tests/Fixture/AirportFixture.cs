using AirportDistanceCalculator.Models;

namespace AirportDistanceCalculator.Tests.Fixture
{
    public class AirportFixture
    {
        public static Airport GetValidAirport => new Airport()
        {
            Country = "Brazil",
            CityIATA = "SAO",
            IATA = "GRU",
            City = "Sao Paulo",
            CountryIATA = "BR",
            Name = "Guarulhos International",
            Location = new Location() {
               Lon= -46.481926,
               Lat= -23.425668
            }
        };

    }
}
