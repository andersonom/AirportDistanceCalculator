using System.Threading.Tasks;

namespace AirportDistanceCalculator.Interfaces.Services
{
    public interface IAirportDistanceService
    {
        Task<double> GetDistanceBetweenAirportsAsync(string IATAFrom, string IATATo);
    }
}
