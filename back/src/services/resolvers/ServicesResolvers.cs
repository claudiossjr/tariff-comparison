using Microsoft.Extensions.DependencyInjection;
using Tariff.Comparison.Domain.Interfaces;
using Tariff.Comparison.Domain.Interfaces.Products;

namespace Tariff.Comparison.Services.Resolvers;

public static class ServicesResolversServiceCollectionExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IFindProductsService, FindProductsService>();
        services.AddScoped<IFindCalculableProductsNamesService, FindCalculableProductsNamesServices>();
        services.AddScoped<ICalculateProductAnnualConsumptionService, CalculateProductAnnualConsumptionFacade>(); 
        return services;
    }
}