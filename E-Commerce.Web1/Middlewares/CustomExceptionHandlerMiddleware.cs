using Shared.ErrorModels;
using System.Net;
using System.Text.Json;

namespace E_Commerce.Web1.Middelwares
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;
        public CustomExceptionHandlerMiddleware(RequestDelegate next, ILogger<CustomExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpcontext)
        {
            try
            {
                await _next.Invoke(httpcontext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong");

                
                // Set Status Code for the response
                httpcontext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                // Set content Type for the response
                httpcontext.Response.ContentType = "application/json";
                // Response Object
                var response = new ErrorDetails
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    ErrorMessage = ex.Message
                };
                // return response as json
                var jsonResult = JsonSerializer.Serialize(response);

                await httpcontext.Response.WriteAsync(jsonResult);
            }
        }


    }
}
