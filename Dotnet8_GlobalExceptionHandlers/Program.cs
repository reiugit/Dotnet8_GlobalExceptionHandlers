using Dotnet8_GlobalExceptionHandlers.ExceptionHandlers;

var builder = WebApplication.CreateBuilder(args);
{
    //ExceptionHandler pipeline:
    builder.Services.AddExceptionHandler<OnlyLoggingExceptionHandler>(); // Only logs exceptions
    builder.Services.AddExceptionHandler<ArgumentExceptionHandler>();    // Handles all ArgumentExceptions
    builder.Services.AddExceptionHandler<DefaultExceptionHandler>();     // Handles all remaining exceptions
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

