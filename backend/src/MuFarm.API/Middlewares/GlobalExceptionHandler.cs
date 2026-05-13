using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MuFarm.API.Middlewares
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            var (statusCode, title) = exception switch
            {
                UnauthorizedAccessException =>
                    (StatusCodes.Status401Unauthorized, "Unauthorized"),

                KeyNotFoundException =>
                    (StatusCodes.Status404NotFound, "Resource Not Found"),

                _ =>
                    (StatusCodes.Status500InternalServerError, "Internal Server Error")
            };

            if (statusCode >= 500)
            {
                logger.LogError(exception,
                    "Unhandled exception occurred");
            }
            else
            {
                logger.LogWarning(exception,
                    "Handled exception occurred");
            }

            var detail = statusCode == 500
                ? "An unexpected error occurred."
                : exception.Message;

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Detail = detail,
                Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}",
                Extensions =
            {
                ["traceId"] = httpContext.TraceIdentifier
            }
            };

            httpContext.Response.StatusCode = statusCode;

            await httpContext.Response.WriteAsJsonAsync(
                problemDetails,
                cancellationToken);

            return true;
        }
    }
}
