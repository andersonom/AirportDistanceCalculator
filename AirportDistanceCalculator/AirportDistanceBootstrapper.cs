using Nancy; 
using Nancy.TinyIoc;

namespace AirportDistanceCalculator
{
    public class AirportDistanceBootstrapper : DefaultNancyBootstrapper
    {        
        private readonly IAppConfiguration appConfig;

        public AirportDistanceBootstrapper()
        {
        }

        public AirportDistanceBootstrapper(IAppConfiguration appConfig)
        {
            this.appConfig = appConfig;
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<IAppConfiguration>(appConfig);
        }
    }
}