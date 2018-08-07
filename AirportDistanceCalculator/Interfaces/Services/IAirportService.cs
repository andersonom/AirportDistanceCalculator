using AirportDistanceCalculator.Models;
using System.Threading.Tasks;

namespace AirportDistanceCalculator.Interfaces.Services
{
    public interface IAirportService
    {
        Task<Airport> GetAirport(string IATA);
    }
}
