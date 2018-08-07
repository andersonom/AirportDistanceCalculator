using AirportDistanceCalculator.Interfaces.Services;
using Nancy;
using Nancy.TinyIoc;

namespace AirportDistanceCalculator
{
    public class AirportDistanceBootstrapper : DefaultNancyBootstrapper
    {
        private readonly IAppConfiguration _appConfig;
        private readonly IAirportService _airportService;
        private readonly IAirportDistanceService _airportDistanceService;

        public AirportDistanceBootstrapper()
        {
        }

        public AirportDistanceBootstrapper(IAppConfiguration appConfig, IAirportService airportService, IAirportDistanceService airportDistanceService)
        {
            _appConfig = appConfig;
            _airportService = airportService;
            _airportDistanceService = airportDistanceService;
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<IAppConfiguration>(_appConfig);
            container.Register<IAirportService>(_airportService);
            container.Register<IAirportDistanceService>(_airportDistanceService);
        }
    }
}