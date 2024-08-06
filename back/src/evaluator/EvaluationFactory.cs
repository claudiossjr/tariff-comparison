using Tariff.Comparison.Domain.Enums;
using Tariff.Comparison.Domain.Interfaces.Evaluation;

namespace Tariff.Comparison.Evaluator;

public class EvaluationFactory : IEvaluationFactory
{
    public IEvaluationService? GetService(TariffType type)
    {
        return type switch {
            TariffType.Basic => new BasicTariffEvaluator(),
            TariffType.Package => new PackageTariffEvaluator(),
            _ => null
        };
    }
}