using AirportDistanceCalculator.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System; 
using System.Net;
using System.Threading.Tasks;

namespace AirportDistanceCalculator.Middleware
{

    /// <summary>
    /// Extension method used to add the middleware to the HTTP request pipeline.
    /// </summary>
    public static class ErrorHandlingMiddleware
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHttpResponseStreamWriterFactory _streamWriterFactory;

        public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, IHttpResponseStreamWriterFactory streamWriterFactory)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = loggerFactory?.CreateLogger<ExceptionMiddleware>() ?? throw new ArgumentNullException(nameof(loggerFactory));
            _streamWriterFactory = streamWriterFactory;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }           
            catch (AirportValidationException ex)
            {
                //TODO
            }
            catch (IETAValidationException ex)
            {
                //TODO
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.InternalServerError;

            _logger.LogError(ex, ex.Message, context);
            await response.WriteAsync(JsonConvert.SerializeObject(ex));
        }
    }

}
