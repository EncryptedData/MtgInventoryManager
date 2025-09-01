using Autofac;
using Autofac.Extensions.DependencyInjection;
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

            ConfigureHost(builder.Host);

            ConfigureServices(builder.Services, builder.Configuration);

            var app = builder.Build();
            app.UseSerilogRequestLogging();
            app.MapControllers();

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

    private static void ConfigureServices(IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddSerilog((services, lc) =>
            lc.ReadFrom.Configuration(configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext()
                .WriteTo.Console());

        services.AddControllers()
            .AddNewtonsoftJson();
    }

    private static void ConfigureHost(ConfigureHostBuilder host)
    {
        host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

        host.ConfigureContainer<ContainerBuilder>(cb => cb.RegisterModule<MtgInventoryManagerModule>());
    }
}