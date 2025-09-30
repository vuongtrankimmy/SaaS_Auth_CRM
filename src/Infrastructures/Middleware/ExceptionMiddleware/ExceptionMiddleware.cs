using Helpers.Helper.Convert;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Infrastructures.Middleware.ExceptionMiddleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ErrorHandlingService _errorHandlingService;

        public GlobalExceptionMiddleware(RequestDelegate next, ErrorHandlingService errorHandlingService)
        {
            _next = next;
            _errorHandlingService = errorHandlingService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _errorHandlingService.HandleException(ex);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result =(new { error = exception.Message }).ToSerialize();
            return context.Response.WriteAsync(result);
        }
    }
}
