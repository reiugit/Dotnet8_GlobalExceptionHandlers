using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet8_GlobalExceptionHandlers.ExceptionHandlers
{
    public class DefaultExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var problemDetails = new ProblemDetails
            {
                Title = "An exception was intentionally invoked.",
                Status = httpContext.Response.StatusCode,
                Detail = exception.Message + " (=> 500 InternalServerError)",
                Instance = httpContext.Request.Path
            };


            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
