using Microsoft.Extensions.DependencyInjection;
using Tariff.Comparison.Consumer.Domain.Interfaces;
using Tariff.Comparison.Provider.external.Client;

namespace Tariff.Comparison.Provider.Resolvers;

public static class ExtenralClientResolversServiceCollectionExtension
{
    public static IServiceCollection AddExternalClients(this IServiceCollection services)
    {
        services.AddScoped<IExternalClient, ExternalClient>();
        return services;
    }
}