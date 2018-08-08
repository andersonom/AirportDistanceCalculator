using System;

namespace AirportDistanceCalculator.Exceptions
{
    public class AirportValidationException : ApplicationException
    {
        public AirportValidationException(string message) : base(message)
        {

        }
    }
}
