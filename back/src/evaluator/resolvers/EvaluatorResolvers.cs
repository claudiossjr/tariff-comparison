using Microsoft.Extensions.DependencyInjection;
using Tariff.Comparison.Domain.Interfaces.Evaluation;

namespace Tariff.Comparison.Evaluator.Resolvers;

public static class EvaluatorResolversServiceCollectionExtension
{
    public static IServiceCollection AddEvaluator(this IServiceCollection services)
    {
        services.AddScoped<IEvaluationFactory, EvaluationFactory>();
        services.AddScoped<IEvaluationService, EvaluatorFacade>();
        return services;
    }
}