using System;
using Nancy;

namespace AirportDistanceCalculator.Exceptions
{
    public class AirportValidationException : CustomExceptionBase
    {
        public AirportValidationException(string message, HttpStatusCode responseCode) : base(message, responseCode)
        {

        }
    }
}
