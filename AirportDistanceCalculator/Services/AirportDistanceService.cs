using AirportDistanceCalculator.Exceptions;
using AirportDistanceCalculator.Helpers;
using AirportDistanceCalculator.Interfaces.Services;
using AirportDistanceCalculator.Models;
using AirportDistanceCalculator.Validators;
using FluentValidation;
using System.Linq;
using System.Threading.Tasks;

namespace AirportDistanceCalculator.Services
{
    public class AirportDistanceService : IAirportDistanceService
    {
        private readonly IAirportService _airportService;
        private readonly AbstractValidator<Airport> _validator;
        private readonly AbstractValidator<string> _IATAValidator;

        public AirportDistanceService(IAirportService airportService)
        {
            _airportService = airportService;
            _validator = new AirportValidator();
            _IATAValidator = new IATAValidator();
        }

        public async Task<double> GetDistanceBetweenAirports(string IATAFrom, string IATATo)
        {
            ValidationResultHelper.ProcessIETAValidationResult(_IATAValidator.Validate(IATAFrom));
            ValidationResultHelper.ProcessIETAValidationResult(_IATAValidator.Validate(IATATo));
             
            var airportFrom = await _airportService.GetAirport(IATAFrom);
            var airportTo = await _airportService.GetAirport(IATATo);

            ValidationResultHelper.ProcessAirportValidationResult(_validator.Validate(airportFrom));
            ValidationResultHelper.ProcessAirportValidationResult(_validator.Validate(airportTo)); 

            return DistanceHelper.DistanceTo(airportFrom.Location.Lat, airportFrom.Location.Lon, airportTo.Location.Lat, airportTo.Location.Lon);
        }         
    }
}
