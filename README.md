# .Net8 Global ExceptionHandlers

Global ExceptionHandlers in .Net 8

* Using the new IExceptionHandler-Interface of .Net 8
* ExceptionHandlers are added to the DI Container
* The order of the exception handlers is important

<b>The first exception handler only logs the error, but does not handle it</b><br>
It return false to indicate that the exception was not handled<br>
and the next exception handler in the pipeline should be invoked<br>
  
<b>The second and third exception handler handle different types of exceptions</b><br>
These exception handlers return true to indicate that the exception was successfully<br>
handled and no more exception handlers in the pipeline should be handled.
