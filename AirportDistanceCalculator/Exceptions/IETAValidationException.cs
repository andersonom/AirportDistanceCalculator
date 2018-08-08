using Nancy;

namespace AirportDistanceCalculator.Exceptions
{
    public class IETAValidationException : CustomExceptionBase
    {
        public IETAValidationException(string message, HttpStatusCode responseCode) : base(message, responseCode)
        {
        }
    }
}