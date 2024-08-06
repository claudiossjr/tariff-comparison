using Tariff.Comparison.Domain.Exceptions;
using Tariff.Comparison.Domain.Interfaces.Evaluation;
using Tariff.Comparison.Domain.Interfaces.Evaluation.Request;
using Tariff.Comparison.Domain.Interfaces.Evaluation.Response;
using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Evaluator;

public class BasicTariffEvaluator : IEvaluationService
{
    public async Task<EvaluationResponse> CalculateAsync(EvaluationRequest request)
    {
        await Task.Yield();
        Product product = request.Product;
        double annualConsumption = request.AnnualConsumption;
        if (annualConsumption < 0) return new EvaluationResponse(false, request.Product, -1);
        ProductTariffDetails details = product.TariffDetails;
        double cost = (details.BaseCost * 12) + (annualConsumption * details.AdditionalKwhCost/100);
        return new EvaluationResponse(true, request.Product, cost);
    }
}
