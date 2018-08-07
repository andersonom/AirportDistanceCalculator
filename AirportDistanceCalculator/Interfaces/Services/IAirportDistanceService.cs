using System.Threading.Tasks;

namespace AirportDistanceCalculator.Interfaces.Services
{
    public interface IAirportDistanceService
    {
        Task<double> GetDistanceBetweenAirports(string IATAFrom, string IATATo);
    }
}
