using AirportDistanceCalculator.Interfaces.Services;
using System.Threading.Tasks;

namespace AirportDistanceCalculator.Services
{
    public class AirportDistanceService : IAirportDistanceService
    {
        private readonly IAirportService _airportService;

        public AirportDistanceService(IAirportService airportService)
        {
            _airportService = airportService;
        }

        public async Task<double> GetDistanceBetweenAirports(string IATAFrom, string IATATo)
        {
            var airportFrom = await _airportService.GetAirport(IATAFrom);
            var airportTo = await _airportService.GetAirport(IATATo);

            return DistanceHelper.DistanceTo(airportFrom.Location.Lat, airportFrom.Location.Lon, airportTo.Location.Lat, airportTo.Location.Lon);
        }
    }
}
