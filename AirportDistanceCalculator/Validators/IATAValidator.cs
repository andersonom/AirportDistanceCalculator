using FluentValidation;

namespace AirportDistanceCalculator.Validators
{
    public class IataValidator : AbstractValidator<string>
    {
        public IataValidator()
        {
            RuleFor(x => x).NotEmpty().Length(3);
        }
    }
}
