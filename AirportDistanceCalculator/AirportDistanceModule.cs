using AirportDistanceCalculator.Exceptions;
using AirportDistanceCalculator.Interfaces.Services;
using AirportDistanceCalculator.Helpers;
using AirportDistanceCalculator.Interfaces;
using Nancy;

namespace AirportDistanceCalculator
{
    public sealed class AirportDistanceModule : NancyModule
    {
        public AirportDistanceModule(IAppConfiguration appConfig, IAirportDistanceService airportDistanceService)
        {
            Get("/", args => "Please fill the route /AirportDistance/{iataFrom}/{iataTo}");

            Get("/AirportDistance/{iataFrom}/{iataTo}", async args => 
                Response.AsJson(await airportDistanceService
                                            .GetDistanceBetweenAirportsAsync(((string)args.iataFrom).Trim().ToUpper(),
                                                                             ((string)args.iataTo).Trim().ToUpper())));

            OnError += (ctx, ex) =>
            {
                switch (ex)
                {
                    case IETAValidationException iEtaValidationEx:
                        return NancyResponseHelper.ProcessNancyResponse(iEtaValidationEx);
                    case AirportValidationException airportValidationEx:
                        return NancyResponseHelper.ProcessNancyResponse(airportValidationEx);
                    default:
                        return 500;
                }
            };
        }
    }
}
