namespace AirportDistanceCalculator.Interfaces
{
    public interface IAppConfiguration
    {
        Logging Logging { get; }
        string CTeleportAPI { get; }
    }
}