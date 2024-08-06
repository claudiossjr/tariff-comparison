using Microsoft.Extensions.DependencyInjection;
using Tariff.Comparison.Domain.Interfaces;
using Tariff.Comparison.Domain.Interfaces.Consumer;
using Tariff.Comparison.Domain.Interfaces.Worker;

namespace Tariff.Comparison.Provider.Queue.Local.Resolvers;

public static class QueueResolversServiceCollectionExtension
{
    public static IServiceCollection AddLocalQueue(this IServiceCollection services)
    {
        services.AddSingleton<ILocalQueue, LocalQueue>();
        services.AddScoped<IQueueConsumerService, LocalQueueConsumerService>();
        services.AddScoped<IQueueProducerService, LocalQueueProducerService>();
        return services;
    }
}