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
        }
    }
}
