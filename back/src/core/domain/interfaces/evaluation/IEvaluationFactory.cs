using Tariff.Comparison.Domain.Enums;

namespace Tariff.Comparison.Domain.Interfaces.Evaluation;

public interface IEvaluationFactory
{
    IEvaluationService? GetService(TariffType type);
}