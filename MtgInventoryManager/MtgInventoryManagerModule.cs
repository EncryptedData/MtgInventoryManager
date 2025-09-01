using Autofac;
using MtgInventoryManager.Models;

namespace MtgInventoryManager;

public class MtgInventoryManagerModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterModule<ModelModule>();
    }
}