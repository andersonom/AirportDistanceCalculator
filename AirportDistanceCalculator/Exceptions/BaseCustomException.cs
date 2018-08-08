using System;
using Nancy;

namespace AirportDistanceCalculator.Exceptions
{
    public class CustomExceptionBase : ApplicationException
    {
        public HttpStatusCode ResponseCode { get; set; }

        public CustomExceptionBase(string message, HttpStatusCode responseCode) : base(message)
        {
            ResponseCode = responseCode;
        }
    }
}