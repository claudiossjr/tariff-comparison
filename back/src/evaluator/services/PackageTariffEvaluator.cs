using Tariff.Comparison.Domain.Exceptions;
using Tariff.Comparison.Domain.Interfaces.Evaluation;
using Tariff.Comparison.Domain.Interfaces.Evaluation.Request;
using Tariff.Comparison.Domain.Interfaces.Evaluation.Response;
using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Evaluator;

public class PackageTariffEvaluator : IEvaluationService
{
    
    public async Task<EvaluationResponse> CalculateAsync(EvaluationRequest request)
    {
        await Task.Yield();
        Product product = request.Product;
        double annualConsumption = request.AnnualConsumption;
        if (annualConsumption < 0) return new EvaluationResponse(false, request.Product, -1);
        ProductTariffDetails tariffDetails = product.TariffDetails;
        double notIncludedKwh = Math.Max(annualConsumption - tariffDetails.IncludedKwh!.Value, 0);
        double normalizedAdditionalCost = tariffDetails.AdditionalKwhCost/100;
        double cost = tariffDetails.BaseCost + (notIncludedKwh * normalizedAdditionalCost);
        return new EvaluationResponse(true, request.Product, cost);
    }
}
