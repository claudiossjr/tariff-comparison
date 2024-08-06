using Tariff.Comparison.Domain.Enums;
using Tariff.Comparison.Domain.Interfaces.Evaluation;

namespace Tariff.Comparison.Evaluator.Test;

public class EvaluatorFactoryTest
{
    private readonly EvaluationFactory _sut;

    public EvaluatorFactoryTest()
    {
        _sut = new();
    }

    [Fact]
    public void ShouldReturnNullIfUnknown()
    {
        IEvaluationService? service = _sut.GetService(TariffType.Unkonwn);

        Assert.Null(service);
    }

    [Fact]
    public void ShouldReturnBasicService()
    {
        IEvaluationService? service = _sut.GetService(TariffType.Basic);

        Assert.Equal(typeof(BasicTariffEvaluator), service!.GetType());
    }

    [Fact]
    public void ShouldReturnPackage()
    {
        IEvaluationService? service = _sut.GetService(TariffType.Package);

        Assert.Equal(typeof(PackageTariffEvaluator), service!.GetType());
    }
}