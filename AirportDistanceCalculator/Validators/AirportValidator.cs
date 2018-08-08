using AirportDistanceCalculator.Models;
using FluentValidation;

namespace AirportDistanceCalculator.Validators
{
    public class AirportValidator : AbstractValidator<Airport>
    {
        public AirportValidator()
        { 
            RuleFor(x => x.IATA).NotEmpty().Length(3);
            RuleFor(x => x.Location.Lat).NotEmpty().GreaterThan(-90).LessThan(90);
            RuleFor(x => x.Location.Lon).NotEmpty().GreaterThan(-180).LessThan(180);
            
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.CityIATA).NotEmpty();
            RuleFor(x => x.Country).NotEmpty();
            RuleFor(x => x.CountryIATA).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
