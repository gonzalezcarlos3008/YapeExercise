using System.Net;
using System.Text.Json;
using Yape.API.Infrastructure.Logging;

namespace Yape.API.Middleware
{
    /// <summary>
    /// Middleware responsible for handling exceptions globally within the application.
    /// It captures unhandled exceptions, logs them, and returns a standardized error response.
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionHandlingMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next middleware in the HTTP request pipeline.</param>
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invokes the middleware to process the incoming HTTP request.
        /// Captures any unhandled exceptions and delegates them to the exception handler.
        /// </summary>
        /// <param name="context">The current HTTP context.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Handles the captured exception and returns a standardized JSON response.
        /// </summary>
        /// <param name="context">The current HTTP context.</param>
        /// <param name="exception">The exception to be handled.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            HttpStatusCode status;
            string message;

            switch (exception)
            {
                case ArgumentException argEx:
                    status = HttpStatusCode.BadRequest;
                    message = argEx.Message;
                    break;
                case UnauthorizedAccessException:
                    status = HttpStatusCode.Unauthorized;
                    message = "Unauthorized access.";
                    break;
                case KeyNotFoundException:
                    status = HttpStatusCode.NotFound;
                    message = "Resource not found.";
                    break;
                default:
                    status = HttpStatusCode.InternalServerError;
                    message = "An unexpected error occurred.";
                    break;
            }

            context.Response.StatusCode = (int)status;

            var response = new
            {
                Error = message,
                StatusCode = context.Response.StatusCode
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}