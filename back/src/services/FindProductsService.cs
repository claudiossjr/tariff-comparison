using Tariff.Comparison.Domain.Interfaces;
using Tariff.Comparison.Domain.Interfaces.Evaluation.Response;
using Tariff.Comparison.Domain.Interfaces.Products;
using Tariff.Comparison.Domain.Interfaces.Products.Request;
using Tariff.Comparison.Domain.Interfaces.Products.Response;

namespace Tariff.Comparison.Services;

public class FindProductsService(IFindCalculableProductsNamesService findCalculableProductsNamesService, ICalculateProductAnnualConsumptionService calculateProductAnnual) : IFindProductsService
{
    private readonly IFindCalculableProductsNamesService _findCalculableProductsNamesService = findCalculableProductsNamesService;
    private readonly ICalculateProductAnnualConsumptionService _calculateProductAnnual = calculateProductAnnual;
    public async Task<FindProductsResponse> FindProductsAsync(FindProductsRequest request)
    {
        // Get all products
        IEnumerable<string> productsNames = await _findCalculableProductsNamesService.FindAsync();
        // Call evaluation for each product
        List<Task<EvaluationResponse>> evaluateTasks = [];
        foreach(string productName in productsNames)
        {
            evaluateTasks.Add(_calculateProductAnnual.CalculateAsync(productName, request.AnnualConsumption));
        }
        // Concatenate responses
        List<EvaluationResponse> evaluations = [.. (await Task.WhenAll(evaluateTasks))];
        // return the result list
        IEnumerable<FindProductResponse> response = evaluations.Where(e => e.Successed).Select(eval => new FindProductResponse(eval.Product!.Name, eval.Product!.RawType, eval.Product!.TypeDescription, eval.Cost)).OrderBy(c => c.AnnualCost);
        return new FindProductsResponse(response);
    }
}
