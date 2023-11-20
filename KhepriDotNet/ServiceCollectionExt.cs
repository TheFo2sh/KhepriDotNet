using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using BindingFlags = System.Reflection.BindingFlags;

namespace KhepriDotNet;

public static class ServiceCollectionExt
{
    public static IServiceCollection AddKhepri(this IServiceCollection services)
    {
        services.AddSingleton<ProxyGenerator>();
        return services;

    }
    public static IServiceCollection AddStore<TStore, TState>(this IServiceCollection services)
        where TStore : Store<TState>
    {
        var parameters=typeof(TStore)
            .GetConstructors(BindingFlags.Public| BindingFlags.Instance)
            .First()
            .GetParameters();
        
        services.AddSingleton<TStore>(provider =>
        {
            var generator = provider.GetRequiredService<ProxyGenerator>();
            return (TStore)generator.CreateClassProxy(typeof(TStore),
                parameters.Select(p => p.ParameterType).Select(provider.GetRequiredService).ToArray(),
                new StoreInterceptor());
        });
        return services;
    }
}