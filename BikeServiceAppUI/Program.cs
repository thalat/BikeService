using BikeServiceAppUI;
using BikeServiceAppUI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureServices();
var app = builder.Build();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjU5OTMxQDMyMzAyZTMxMmUzMGFQK1B3UHljZzRPc040YjFubndZTVQxTElMSWNET0MxZGM4NFNsdkIwMlE9");

if (!app.Environment.IsDevelopment())
{
   app.UseExceptionHandler("/Error");
   app.UseHsts();
}
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapRazorPages();
app.UseMiddleware<LoggingMiddleware>();

app.Run();
