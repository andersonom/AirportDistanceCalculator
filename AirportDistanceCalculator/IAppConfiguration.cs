using static AirportDistanceCalculator.AppConfiguration;

namespace AirportDistanceCalculator
{
    public interface IAppConfiguration
    {
        Logging Logging { get; }
        string CTeleportAPI { get; }
    }
}