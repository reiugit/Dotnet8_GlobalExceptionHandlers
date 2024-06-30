using Microsoft.AspNetCore.Diagnostics;

namespace Dotnet8_GlobalExceptionHandlers.ExceptionHandlers
{
    public class OnlyLoggingExceptionHandler(ILogger<OnlyLoggingExceptionHandler> logger) : IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            logger.LogInformation("An exception was intentionally invoked:  StatusCode {StatusCode}\n      {message}",
                                         httpContext.Response.StatusCode,
                                         exception.Message);

            return ValueTask.FromResult(false);
        }
    }
}
