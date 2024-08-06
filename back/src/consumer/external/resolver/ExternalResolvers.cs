using Microsoft.Extensions.DependencyInjection;
using Tariff.Comparison.Domain.Interfaces.Consumer;
using Tariff.Comparison.External.Consumer;

namespace Tariff.Comparison.External.Resolvers;

public static class ExternalResolversServiceCollectionExtension
{
    public static IServiceCollection AddExtenalServices(this IServiceCollection services)
    {
        services.AddScoped<IExternalTariffConsumer, ExternalTariffConsumer>();
        services.AddScoped<IExternalTariffRegister, ExternalTariffRegister>();
        return services;
    }
}