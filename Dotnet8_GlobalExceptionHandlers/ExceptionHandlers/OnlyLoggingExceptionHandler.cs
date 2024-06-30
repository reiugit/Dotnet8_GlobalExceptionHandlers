using Microsoft.AspNetCore.Diagnostics;

namespace Dotnet8_GlobalExceptionHandlers.ExceptionHandlers
{
    public class OnlyLoggingExceptionHandler(ILogger<OnlyLoggingExceptionHandler> logger) : IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            logger.LogInformation("An exception was intentionally invoked:  StatusCode {StatusCode}\n      {message}\n",
                                         httpContext.Response.StatusCode,
                                         exception.Message);

            // return false to indicate that the exception was not handled
            // and the next exception handler in the pipeline should be invoked
            return ValueTask.FromResult(false);
        }
    }
}
