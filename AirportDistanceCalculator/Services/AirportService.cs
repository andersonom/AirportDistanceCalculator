﻿using AirportDistanceCalculator.Interfaces.Services;
using AirportDistanceCalculator.Models;
using System.Threading.Tasks;
using AirportDistanceCalculator.Exceptions;
using AirportDistanceCalculator.Helpers;
using AirportDistanceCalculator.Validators;
using FluentValidation;
using Flurl.Http;
using Newtonsoft.Json;

namespace AirportDistanceCalculator.Services
{
    public class AirportService : IAirportService
    {
        private readonly IAppConfiguration _appConfig;
        private readonly AbstractValidator<string> _iataValidator;
        private readonly AbstractValidator<Airport> _validator;

        public AirportService(IAppConfiguration appConfig)
        {
            _appConfig = appConfig;
            _iataValidator = new IataValidator();
            _validator = new AirportValidator();
        }

        public async Task<Airport> GetAirportAsync(string iata)
        {
            ValidationResultHelper.ProcessIETAValidationResult(_iataValidator.Validate(iata));

            var result = await _appConfig.CTeleportAPI
                .AllowAnyHttpStatus()
                .AppendPathSegment(iata)
                .GetAsync();

            var response = result.Content.ReadAsStringAsync().Result;

            if (result.IsSuccessStatusCode)
            {
                var airport = JsonConvert.DeserializeObject<Airport>(response);
                ValidationResultHelper.ProcessAirportValidationResult(_validator.Validate(airport));
                return airport;
            }

            throw new IETAValidationException(response, (Nancy.HttpStatusCode)result.StatusCode);
        }
    }
}
