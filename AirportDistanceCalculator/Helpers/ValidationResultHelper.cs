using AirportDistanceCalculator.Exceptions;
using Nancy;

namespace AirportDistanceCalculator.Helpers
{
    public static class ValidationResultHelper
    {
        public static void ProcessIETAValidationResult(FluentValidation.Results.ValidationResult result)
        {
            if (!result.IsValid)
                throw new IETAValidationException(ValidationErrorsHelper.AggregateErrorMessages(result), HttpStatusCode.BadRequest);
        }

        public static void ProcessAirportValidationResult(FluentValidation.Results.ValidationResult result)
        {
            if (!result.IsValid)
                throw new AirportValidationException(ValidationErrorsHelper.AggregateErrorMessages(result), HttpStatusCode.BadRequest);
        }
    }
}
