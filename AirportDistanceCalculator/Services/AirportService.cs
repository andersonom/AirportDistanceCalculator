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

            //var result = await _appConfig.CTeleportAPI
            //    .AllowAnyHttpStatus()
            //    .AppendPathSegment(IATA)
            //    .GetAsync();

            //var response = result.Content.ReadAsStringAsync().Result;
            //if (result.IsSuccessStatusCode)
            //{
            //    var ret = JsonConvert.DeserializeObject<Airport>(response);
            //    return ret;
            //}
            //throw new Exception(response + result.StatusCode);
        }
    }
}
