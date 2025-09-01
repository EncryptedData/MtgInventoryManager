using Autofac;
using MtgInventoryManager.Common.Extensions;
using MtgInventoryManager.Models.Abstractions;
using MtgInventoryManager.Models.Configuration;
using MtgInventoryManager.Models.Factories;

namespace MtgInventoryManager.Models;

public class ModelModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterOptions<ConnectionStringsConfig>(ConnectionStringsConfig.Path);
        
        builder.RegisterType<DatabaseContextFactory>().As<IDatabaseContextFactory>().SingleInstance();
    }
}