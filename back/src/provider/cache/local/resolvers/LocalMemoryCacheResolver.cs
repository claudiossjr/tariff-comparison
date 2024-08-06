using Microsoft.Extensions.DependencyInjection;
using Tariff.Comparison.Domain.Interfaces.Cache;

namespace Tariff.Comparison.Provider.Cache.Local.Resolvers;

public static class LocalMemoryCacheResolverServiceCollectionExtension
{
    public static IServiceCollection AddLocalCache(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddScoped<ICacheService, LocalMemoryCacheService>();
        return services;
    }
}