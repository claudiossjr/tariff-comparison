using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Domain.Interfaces.Evaluation.Request;

public record EvaluationRequest(Product Product, double AnnualConsumption);