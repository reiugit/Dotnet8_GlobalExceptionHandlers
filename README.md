# .Net8 Global ExceptionHandlers

Global ExceptionHandlers in .Net 8

* Using the new IExceptionHandler-Interface of .Net 8
* ExceptionHandlers are added to the DI Container
* The order of the exception handlers is important

### The first exception handler is OnlyLoggingExceptionHandler
* it only logs the error, but does not handle it
* it return false to indicate that the exception was not handled  
  and the next exception handler in the pipeline should be invoked
  
### The second and third exception handler handle different types of exceptions
