using AirportDistanceCalculator.Interfaces.Services;
using Nancy; 

namespace AirportDistanceCalculator
{
    public class AirportDistanceModule : NancyModule
    {
        public AirportDistanceModule(IAppConfiguration appConfig, IAirportDistanceService airportDistanceService)
        {
            Get("/", args => "Please fill the route /AirportDistance/{iataFrom}/to/{iataTo}");

            Get("/AirportDistance/{iataFrom}/to/{iataTo}", args => 
            
            Response.AsJson(airportDistanceService

            .GetDistanceBetweenAirports(((string)args.iataFrom).Trim().ToUpper(),
                                        ((string)args.iataTo).Trim().ToUpper()).Result));             
        }
    }
}
