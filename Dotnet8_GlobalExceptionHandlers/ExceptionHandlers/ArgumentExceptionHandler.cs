using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet8_GlobalExceptionHandlers.ExceptionHandlers
{
    public class ArgumentExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not ArgumentException)
            {
                return false;
            }

            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            var problemDetails = new ProblemDetails
            {
                Title = "An argument exception was intentionally invoked.",
                Status = httpContext.Response.StatusCode,
                Detail = exception.Message + " (=> 400 BadRequest)",
                Instance = httpContext.Request.Path
            };


            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
