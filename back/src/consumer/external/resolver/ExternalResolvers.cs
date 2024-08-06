using Microsoft.Extensions.DependencyInjection;
using Tariff.Comparison.Consumer.Domain.Interfaces.Adapters;
using Tariff.Comparison.Domain.Interfaces.Consumer;
using Tariff.Comparison.External.Consumer;
using Tariff.Comparison.External.Converters;

namespace Tariff.Comparison.External.Resolvers;

public static class ExternalResolversServiceCollectionExtension
{
    public static IServiceCollection AddExtenalServices(this IServiceCollection services)
    {
        services.AddScoped<IExternalTariffConsumer, ExternalTariffConsumer>();
        services.AddScoped<IExternalTariffRegister, ExternalTariffRegister>();
        services.AddScoped<IExternalProductConverter, ExternalProductConverter>();
        return services;
    }
}