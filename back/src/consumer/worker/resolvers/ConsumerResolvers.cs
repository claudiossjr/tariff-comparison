using Microsoft.Extensions.DependencyInjection;
using Tariff.Comparison.Domain.Interfaces.Worker;

namespace Tariff.Comparison.Consumer.Worker.Resolvers;

public static class ConsumerResolversServiceCollectionExtension
{
    public static IServiceCollection AddConsumers(this IServiceCollection services)
    {
        services.AddScoped<IProductConsumerWorker, ProductConsumerWorker>();
        return services;
    }
}