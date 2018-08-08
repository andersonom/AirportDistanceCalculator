using AirportDistanceCalculator.Exceptions;
using AirportDistanceCalculator.Interfaces.Services;
using AirportDistanceCalculator.Helpers;
using Nancy;

namespace AirportDistanceCalculator
{
    public class AirportDistanceModule : NancyModule
    {
        public AirportDistanceModule(IAppConfiguration appConfig, IAirportDistanceService airportDistanceService)
        {
            Get("/", args => "Please fill the route /AirportDistance/{iataFrom}/{iataTo}");

            Get("/AirportDistance/{iataFrom}/{iataTo}", args =>

            Response.AsJson(airportDistanceService

            .GetDistanceBetweenAirportsAsync(((string)args.iataFrom).Trim().ToUpper(),
                                        ((string)args.iataTo).Trim().ToUpper()).Result));
            
            OnError += (ctx, ex) =>
            {
                switch (ex)
                {
                    case IETAValidationException iETAValidationEx:
                        return NancyResponseHelper.ProcessNancyResponse(iETAValidationEx);
                    case AirportValidationException airportValidationEx:
                        return NancyResponseHelper.ProcessNancyResponse(airportValidationEx);
                    default:
                        return 500;
                }
            };
        }
    }
}
