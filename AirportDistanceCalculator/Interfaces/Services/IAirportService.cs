using AirportDistanceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportDistanceCalculator.Interfaces.Services
{
    public interface IAirportService
    {
        Task<Airport> GetAirport(string IATA);
    }
}
