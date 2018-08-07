using AirportDistanceCalculator.Interfaces.Services;
using Nancy;
using Nancy.TinyIoc;

namespace AirportDistanceCalculator
{
    public class AirportDistanceBootstrapper : DefaultNancyBootstrapper
    {
        private readonly IAppConfiguration _appConfig;
        private readonly IAirportService _airportService;

        public AirportDistanceBootstrapper()
        {
        }

        public AirportDistanceBootstrapper(IAppConfiguration appConfig, IAirportService airportService)
        {
            _appConfig = appConfig;
            _airportService = airportService;
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<IAppConfiguration>(_appConfig);
            container.Register<IAirportService>(_airportService);
        }
    }
}