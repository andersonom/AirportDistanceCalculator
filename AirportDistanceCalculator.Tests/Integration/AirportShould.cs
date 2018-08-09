using System;
using Nancy;
using Nancy.Testing;
using Xunit;

namespace AirportDistanceCalculator.Tests.Integration
{
    public class AirportShould
    {
        [Fact]
        public void ReturnOKWhenDefaultRouteHit()
        {
            var bootstrapper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstrapper);

            // When
            var result = browser.Get("/", with => { with.HttpRequest(); });

            // Then
            Assert.Equal(HttpStatusCode.OK, result.Result.StatusCode);
        }

        [Fact]
        public void ReturnOKWhenAirportDistanceRouteHits()
        {
            var bootstrapper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstrapper, defaults: to => to.Accept("application/json"));
            //var browser = new Browser(with => with.Module<AirportDistanceModule>());
            // When
            var result = browser.Get("/AirportDistance/", with =>
            {
                with.HttpRequest();
                with.Query("iataFrom", "AMS");
                with.Query("iataTo", "GRU");
            });
            //TODO: Fix - Not working with two querystrings
            Console.WriteLine(result.Result.StatusCode);

            // Then
            Assert.Equal(HttpStatusCode.OK, result.Result.StatusCode);
        } 

        [Fact]
        public void ReturnNotFoundWhenRouteDoesntExist()
        {
            var bootstrapper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstrapper);

            // When
            var result = browser.Get("/bla", with => { with.HttpRequest(); });

            // Then
            Assert.Equal(HttpStatusCode.NotFound, result.Result.StatusCode);
        }

        public void ReturnNotFoundWhenInexistentAirport()
        {
        }
    }
}
