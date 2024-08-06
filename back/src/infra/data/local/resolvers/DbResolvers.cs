using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Tariff.Comparison.Data.Local.Resolvers;

public static class LocalDbResolverServiceCollectionExtension
{
    public static IServiceCollection ResolveDatabase(this IServiceCollection services)
    {
        services.AddDbContext<ProductsContext>(options => options.UseInMemoryDatabase("products"));
        return services;
    }
}