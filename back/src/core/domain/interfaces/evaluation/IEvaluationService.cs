using Tariff.Comparison.Domain.Interfaces.Evaluation.Request;
using Tariff.Comparison.Domain.Interfaces.Evaluation.Response;
using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Domain.Interfaces.Evaluation;

public interface IEvaluationService
{
    Task<EvaluationResponse> CalculateAsync(EvaluationRequest request);
}