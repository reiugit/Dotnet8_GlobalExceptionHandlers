using Dotnet8_GlobalExceptionHandlers.ExceptionHandlers;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddExceptionHandler<ArgumentExceptionHandler>(); // handles all ArgumentExceptions
    builder.Services.AddExceptionHandler<DefaultExceptionHandler>();  // handles all remaining exceptions
    builder.Services.AddProblemDetails();
}

var app = builder.Build();
{
    app.UseExceptionHandler();
}

app.MapGet("/InvokeArgumentException", () =>
{
    throw new ArgumentException("An ArgumentException was invoked to trigger the ArgumentExceptionHandler.");
});

app.MapGet("/InvokeDefaultException", () =>
{
    throw new Exception("An Exception was invoked to trigger the DefaultExceptionHandler.");
});

app.Run();

