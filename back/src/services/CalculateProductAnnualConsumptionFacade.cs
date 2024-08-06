using Microsoft.Extensions.DependencyInjection;
using Tariff.Comparison.Domain.Interfaces.Cache;
using Tariff.Comparison.Domain.Interfaces.Cache.Request;
using Tariff.Comparison.Domain.Interfaces.Evaluation;
using Tariff.Comparison.Domain.Interfaces.Evaluation.Request;
using Tariff.Comparison.Domain.Interfaces.Evaluation.Response;
using Tariff.Comparison.Domain.Interfaces.Products;
using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Services;

public class CalculateProductAnnualConsumptionFacade(IServiceProvider serviceProvider) : ICalculateProductAnnualConsumptionService
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    public async Task<EvaluationResponse> CalculateAsync(string productName, double annualConsumption)
    {
        using IServiceScope scope = _serviceProvider.CreateScope();
        IEvaluationService evaluationService = scope.ServiceProvider.GetRequiredService<IEvaluationService>();
        ICacheService cacheService = scope.ServiceProvider.GetRequiredService<ICacheService>();
        Product? product = (await cacheService.Find<Product>(new CacheRequest(productName)))?.Value;
        if (product == null) return new EvaluationResponse(false, product, -1);
        return await evaluationService.CalculateAsync(new EvaluationRequest(product!, annualConsumption));
    }
}
