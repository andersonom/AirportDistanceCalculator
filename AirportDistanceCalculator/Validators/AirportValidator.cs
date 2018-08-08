using AirportDistanceCalculator.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportDistanceCalculator.Validators
{
    public class AirportValidator : AbstractValidator<Airport>
    {
        public AirportValidator()
        { 
            this.RuleFor(x => x.IATA).NotEmpty().Length(3);
            this.RuleFor(x => x.Location.Lat).NotEmpty().GreaterThan(0);
            this.RuleFor(x => x.Location.Lon).NotEmpty().GreaterThan(0); 
        }
    }
}
