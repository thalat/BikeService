using BikeServiceAppUI.Middleware;

namespace BikeServiceAppUI;

public static class RegisterServices
{
   public static void ConfigureServices(this WebApplicationBuilder builder)
   {
      builder.Services.AddRazorPages();
      builder.Services.AddServerSideBlazor();
      builder.Services.AddMemoryCache();

      builder.Services.AddSingleton<IDbConnection, DbConnection>();
      builder.Services.AddSingleton<IClientData, MongoClientData>();
      builder.Services.AddSingleton<IStatusData, MongoStatusData>();
      builder.Services.AddSingleton<IServiceTicketData, MongoServiceTicketData>();
      builder.Services.AddSingleton<IRepairItemData, MongoRepairItemData>();
      builder.Services.AddSingleton<IServiceSetData, MongoServiceSetData>();
      builder.Services.AddSingleton<LoggingMiddleware>();
      builder.Services.AddScoped<ErrorHandlingMiddleware>();
      builder.Services.AddSyncfusionBlazor();
   }
}
