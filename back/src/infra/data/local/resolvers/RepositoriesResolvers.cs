using Microsoft.Extensions.DependencyInjection;
using Tariff.Comparison.Data.Local.Repositories;
using Tariff.Comparison.Domain.Interfaces.Repository;

namespace Tariff.Comparison.Data.Local.Resolvers;

public static class RepositoriesResolversServiceCollectionExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IFindProductsRepository, LocalFindProductsRepository>();
        services.AddScoped<ISaveProductRepository, LocalSaveProductRepository>();
        return services;
    }
}