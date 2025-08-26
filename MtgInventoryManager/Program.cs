using Serilog;

namespace MtgInventoryManager;

internal static class Program
{
    public static async Task Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

        try
        {
            var builder = WebApplication.CreateBuilder(args);
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
