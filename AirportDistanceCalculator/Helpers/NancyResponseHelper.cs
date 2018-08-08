using AirportDistanceCalculator.Exceptions;
using Nancy;

namespace AirportDistanceCalculator.Helpers
{
    public static class NancyResponseHelper
    {
        public static Response ProcessNancyResponse(CustomExceptionBase airportValidationException)
        {
            Response response = airportValidationException.Message;
            response.StatusCode = airportValidationException.ResponseCode;

            return response;
        }
    }
}
