using AirportDistanceCalculator.Interfaces.Services;
using AirportDistanceCalculator.Models;
using System.Threading.Tasks;
using AirportDistanceCalculator.Helpers;

namespace AirportDistanceCalculator.Services
{
    public class AirportDistanceService : IAirportDistanceService
    {
        private readonly IAirportService _airportService;

        public AirportDistanceService(IAirportService airportService)
        {
            _airportService = airportService;
        }

        public async Task<double> GetDistanceBetweenAirportsAsync(string iataFrom, string iataTo)
        {
            Airport airportFrom = await _airportService.GetAirportAsync(iataFrom);
            Airport airportTo = await _airportService.GetAirportAsync(iataTo);
 
            return DistanceHelper.DistanceTo(airportFrom.Location.Lat, airportFrom.Location.Lon, airportTo.Location.Lat, airportTo.Location.Lon);
        }         
    }
}
