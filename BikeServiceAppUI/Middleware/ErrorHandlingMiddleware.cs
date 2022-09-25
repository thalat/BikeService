using BikeServiceAppUI.Exceptions;

namespace BikeServiceAppUI.Middleware;

public class ErrorHandlingMiddleware : IMiddleware
{
   private readonly ILogger<ErrorHandlingMiddleware> _logger;
   public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
   {
      _logger = logger;
   }
   public async Task InvokeAsync(HttpContext context, RequestDelegate next)
   {
      try
      {
         await next.Invoke(context);
      }

      catch (BadRequestException badrequestexception)
      {
         context.Response.StatusCode = 400;
         await context.Response.WriteAsync(badrequestexception.Message);
      }

      catch (Exception e)
      {
         _logger.LogError(e, e.Message);

         context.Response.StatusCode = 500;
         await context.Response.WriteAsync("Something went wrong");
      }
   }
}
