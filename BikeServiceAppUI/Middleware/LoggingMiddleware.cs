using System.Diagnostics;

namespace BikeServiceAppUI.Middleware;

public class LoggingMiddleware : IMiddleware
{
   public async Task InvokeAsync(HttpContext context, RequestDelegate next)
   {
      Debug.WriteLine(context.Request.Path);

      try
      {
         await next(context);
      }
      catch (Exception e)
      {
         Debug.WriteLine(e.Message);
         throw;
      }

   }
}
