using Tariff.Comparison.Domain.Interfaces.Evaluation.Response;

namespace Tariff.Comparison.Domain.Interfaces.Products;

public interface ICalculateProductAnnualConsumptionService
{
    Task<EvaluationResponse> CalculateAsync(string productName, double annualConsumption);
    
}