using System; 

namespace AirportDistanceCalculator.Exceptions
{
    public class IETAValidationException : ApplicationException
    {
        public IETAValidationException(string message) : base(message)
        {

        }
    }
}
