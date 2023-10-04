using Application.Core.Common.Exceptions;
using System.Net;
using WebApi.Models;


namespace WebApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var error = new Error
            {
                StatusCode = httpContext.Response.StatusCode.ToString(),
                Message = exception.Message
            };

            if (exception is ValidationException validationException)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                error.StatusCode = httpContext.Response.StatusCode.ToString();
                error.Detail = string.Join(" ", validationException.Errors);
            }

            if (exception is NotFoundException)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                error.StatusCode = httpContext.Response.StatusCode.ToString();
                error.Message = exception.Message;
            }

            await httpContext.Response.WriteAsync(error.ToString());
        }
    }
}
