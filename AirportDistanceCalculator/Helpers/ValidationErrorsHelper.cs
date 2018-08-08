using System.Linq; 

namespace AirportDistanceCalculator.Helpers
{
    public static class ValidationErrorsHelper
    {
        public static string AggregateErrorMessages(FluentValidation.Results.ValidationResult result)
        {
            return result.Errors.Aggregate("",
                                (current, failure) => current + failure.ErrorMessage + System.Environment.NewLine);
        }
    }
}
