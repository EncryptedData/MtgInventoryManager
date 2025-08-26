using Serilog;

namespace MtgInventoryManager;

internal static class Program
{
    public static async Task Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateBootstrapLogger();

        try
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSerilog((services, lc) =>
                lc.ReadFrom.Configuration(builder.Configuration).ReadFrom.Services(services).Enrich.FromLogContext()
                    .WriteTo.Console());
            
            var app = builder.Build();
            app.UseSerilogRequestLogging();

            app.MapGet("/", () => "Hello World!");

            await app.RunAsync();
        }
        catch (Exception e)
        {
            Log.Fatal(e, $"Application caught exception in main");
        }
        finally
        {
            await Log.CloseAndFlushAsync();
        }
    }
}
