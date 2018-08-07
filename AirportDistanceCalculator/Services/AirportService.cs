using AirportDistanceCalculator.Interfaces.Services;
using AirportDistanceCalculator.Models;
using System.Threading.Tasks;
using Flurl.Http; 

namespace AirportDistanceCalculator.Services
{
    public class AirportService : IAirportService
    {
        private readonly IAppConfiguration _appConfig;

        public AirportService(IAppConfiguration appConfig)
        {
            _appConfig = appConfig;
        }

        public async Task<Airport> GetAirport(string IATA)
        {
            return await _appConfig.CTeleportAPI
                .AllowAnyHttpStatus()
                .AppendPathSegment(IATA)
                .GetJsonAsync<Airport>(); 
        }
    }
}
