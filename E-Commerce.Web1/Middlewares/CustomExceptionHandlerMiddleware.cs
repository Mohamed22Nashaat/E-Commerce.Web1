using Domain.Exceptions;
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
                //Logic
                await HandleNotFoundEndPointAsync(httpcontext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong");
                await HandleExceptionAsync(httpcontext, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpcontext, Exception ex)
        {
            // Set Status Code for the response
            //httpcontext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            // Set content Type for the response
            httpcontext.Response.ContentType = "application/json";
            // Response Object
            var response = new ErrorDetails
            {

                ErrorMessage = ex.Message
            };

            response.StatusCode = ex switch
            {
                NotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError
            };
            // return response as json
            var jsonResult = JsonSerializer.Serialize(response);

            await httpcontext.Response.WriteAsync(jsonResult);
        }

        private static async Task HandleNotFoundEndPointAsync(HttpContext httpcontext)
        {
            if (httpcontext.Response.StatusCode == (int)HttpStatusCode.NotFound)
            {
                httpcontext.Response.ContentType = "application/json";
                var response = new ErrorDetails
                {

                    ErrorMessage = $"End Point {httpcontext.Request.Path} Not Found",
                    StatusCode = (int)HttpStatusCode.NotFound
                };
                await httpcontext.Response.WriteAsJsonAsync(response);
            }
        }

    }
    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionHandlerMiddleware>();
            return app;
        }
    }
}
