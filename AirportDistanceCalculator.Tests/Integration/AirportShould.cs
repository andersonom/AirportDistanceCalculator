using Nancy;
using Nancy.Testing;
using Xunit;

namespace AirportDistanceCalculator.Tests.Integration
{
    public class AirportShould
    {
        [Fact]
        public void ReturnOKWhenDefaultRouteExists()
        {
            var bootstrapper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstrapper);

            // When
            var result = browser.Get("/", with =>
            {
                with.HttpRequest();
            });

            // Then
            Assert.Equal(HttpStatusCode.OK, result.Result.StatusCode);
        }
        [Fact]
        public void ReturnOKWhenAirportDistanceRouteExists()
        {
            var bootstrapper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstrapper, defaults: to => to.Accept("application/json"));

            // When
            var result = browser.Get("/AirportDistance/", with =>
            {
                with.HttpRequest();
                with.Query("iataFrom", "ATL");
                with.Query("iataTo", "DFW");
            });

            // Then
            Assert.Equal(HttpStatusCode.OK, result.Result.StatusCode);
        }

        public void ReturnBadRequest()
        {
            
        }
        public void ReturnNotFound()
        {

        }
    }
}
