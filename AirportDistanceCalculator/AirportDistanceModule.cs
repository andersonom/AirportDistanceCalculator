﻿using AirportDistanceCalculator.Interfaces.Services;
using AirportDistanceCalculator.Models;
using Nancy;

namespace AirportDistanceCalculator
{
    public class AirportDistanceModule : NancyModule
    {
        public AirportDistanceModule(IAppConfiguration appConfig, IAirportService airportService)
        {
            Get("/", args => "Please fill the route /AirportDistance/{iata1}/to/{iata2}");

            Get("/AirportDistance/{iata1}/to/{iata2}", args => Response.AsJson(airportService.GetAirport((string)args.iata1)));

            Get("/Airport/{name}", args => Response.AsJson(new Airport() { Name = args.name }));
        }
    }
}
