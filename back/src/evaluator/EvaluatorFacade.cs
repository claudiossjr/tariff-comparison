using Tariff.Comparison.Domain.Enums;
using Tariff.Comparison.Domain.Interfaces.Evaluation;
using Tariff.Comparison.Domain.Interfaces.Evaluation.Request;
using Tariff.Comparison.Domain.Interfaces.Evaluation.Response;
using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Evaluator;

public class EvaluatorFacade(IEvaluationFactory evaluationFactory) : IEvaluationService
{
    private readonly IEvaluationFactory _evaluationFactory = evaluationFactory;

    public async Task<EvaluationResponse> CalculateAsync(EvaluationRequest request)
    {
        IEvaluationService? evaluationService = _evaluationFactory.GetService(request.Product.Type);
        if (evaluationService == null) return new EvaluationResponse(false, request.Product, -1);
        EvaluationResponse response = await evaluationService.CalculateAsync(request);
        return response;        
    }
}
