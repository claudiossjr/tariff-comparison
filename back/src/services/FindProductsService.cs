using Microsoft.Extensions.DependencyInjection;
using Tariff.Comparison.Domain.Enums;
using Tariff.Comparison.Domain.Interfaces;
using Tariff.Comparison.Domain.Interfaces.Cache;
using Tariff.Comparison.Domain.Interfaces.Cache.Request;
using Tariff.Comparison.Domain.Interfaces.Evaluation;
using Tariff.Comparison.Domain.Interfaces.Evaluation.Request;
using Tariff.Comparison.Domain.Interfaces.Evaluation.Response;
using Tariff.Comparison.Domain.Interfaces.Products;
using Tariff.Comparison.Domain.Interfaces.Products.Request;
using Tariff.Comparison.Domain.Interfaces.Products.Response;
using Tariff.Comparison.Domain.Interfaces.Repository;
using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Services;

public class FindProductsService(IFindCalculableProductsNamesService findCalculableProductsNamesService, IServiceProvider serviceProvider) : IFindProductsService
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly IFindCalculableProductsNamesService _findCalculableProductsNamesService = findCalculableProductsNamesService;
    public async Task<FindProductsResponse> FindProductsAsync(FindProductsRequest request)
    {
        // Get all products
        IEnumerable<string> productsNames = await _findCalculableProductsNamesService.FindAsync();
        // Call evaluation for each product
        List<Task<EvaluationResponse>> evaluateTasks = [];
        foreach(string productName in productsNames)
        {
            evaluateTasks.Add(CalculateAsync(productName, request.AnnualConsumption));
        }
        // Concatenate responses
        List<EvaluationResponse> evaluations = [.. (await Task.WhenAll(evaluateTasks))];
        // return the result list
        IEnumerable<FindProductResponse> response = evaluations.Where(e => e.Successed).Select(eval => new FindProductResponse(eval.Product!.Name, eval.Product!.RawType, eval.Product!.TypeDescription, eval.Cost));
        return new FindProductsResponse(response);
    }

    private async Task<EvaluationResponse> CalculateAsync(string productName, double annualConsumption)
    {
        using IServiceScope scope = _serviceProvider.CreateScope();
        IEvaluationService evaluationService = scope.ServiceProvider.GetRequiredService<IEvaluationService>();
        ICacheService cacheService = scope.ServiceProvider.GetRequiredService<ICacheService>();
        Product? product = (await cacheService.Find<Product>(new CacheRequest(productName)))?.Value;
        if (product == null) return new EvaluationResponse(false, product, -1);
        return await evaluationService.CalculateAsync(new EvaluationRequest(product!, annualConsumption));
    }
}
