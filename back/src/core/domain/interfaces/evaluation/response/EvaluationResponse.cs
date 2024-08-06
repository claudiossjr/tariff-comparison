using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Domain.Interfaces.Evaluation.Response;

public record EvaluationResponse(bool Successed, Product? Product, double Cost);