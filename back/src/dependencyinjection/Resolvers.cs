using Microsoft.Extensions.DependencyInjection;
using Tariff.Comparison.Consumer.Worker.Resolvers;
using Tariff.Comparison.Data.Local.Resolvers;
using Tariff.Comparison.Evaluator.Resolvers;
using Tariff.Comparison.External.Resolvers;
using Tariff.Comparison.Provider.Cache.Local.Resolvers;
using Tariff.Comparison.Provider.Queue.Local.Resolvers;
using Tariff.Comparison.Provider.Resolvers;
using Tariff.Comparison.Services.Resolvers;

namespace Tariff.Comparison.DI;

public static class ResolversServiceCollectionExtension
{
    public static IServiceCollection AddResolvers(this IServiceCollection services)
    {
        services.AddConsumers();
        services.AddExtenalServices();
        services.AddExternalClients();

        services.AddEvaluator();

        services.ResolveDatabase();
        services.AddRepositories();

        services.AddLocalCache();
        services.AddLocalQueue();

        services.AddServices();
        return services;
    }

}
