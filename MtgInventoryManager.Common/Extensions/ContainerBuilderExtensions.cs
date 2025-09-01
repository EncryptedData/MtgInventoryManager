using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NullReferenceException = System.NullReferenceException;

namespace MtgInventoryManager.Common.Extensions;

public static class ContainerBuilderExtensions
{
    public static ContainerBuilder RegisterOptions<T>(this ContainerBuilder builder, string path) 
        where T: class, new()
    {
        builder.Register<T>(context =>
        {
            var config = context.Resolve<IConfiguration>();

            return config.GetSection(path).Get<T>() ?? throw new NullReferenceException();
        }).AsSelf().SingleInstance();

        builder.Register(context =>
        {
            var config = context.Resolve<IConfiguration>();

            return Options.Create(config.GetSection(path).Get<T>() ?? throw new NullReferenceException());
        }).AsSelf().SingleInstance();

        return builder;
    }
}