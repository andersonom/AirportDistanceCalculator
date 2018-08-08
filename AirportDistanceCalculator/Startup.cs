﻿using AirportDistanceCalculator.Middleware;
using AirportDistanceCalculator.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nancy.Owin;

namespace AirportDistanceCalculator
{
    public class Startup
    {
        private readonly IConfiguration _config; 

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                              .AddJsonFile("appsettings.json")
                              .SetBasePath(env.ContentRootPath);

            _config = builder.Build(); 
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        { 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            var appConfig = new AppConfiguration();
            ConfigurationBinder.Bind(_config, appConfig);

            var airportService = new AirportService(appConfig);
            var airportDistanceService = new AirportDistanceService(airportService);

            //TODO Add MVC to inject IHttpResponseStreamWriterFactory inside UseExceptionMiddleware ?

            app.UseExceptionMiddleware();

            app.UseOwin(x => x.UseNancy(opt => opt.Bootstrapper = new AirportDistanceBootstrapper(appConfig, airportService, airportDistanceService)));
        }
    }
}
