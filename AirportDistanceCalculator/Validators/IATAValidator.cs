using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportDistanceCalculator.Validators
{
    public class IATAValidator : AbstractValidator<string>
    {
        public IATAValidator()
        {
            this.RuleFor(x => x).NotEmpty().Length(3);
        }
    }
}
