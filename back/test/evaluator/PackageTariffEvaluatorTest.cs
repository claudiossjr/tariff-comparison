using Tariff.Comparison.Domain.Enums;
using Tariff.Comparison.Domain.Exceptions;
using Tariff.Comparison.Domain.Interfaces.Evaluation.Request;
using Tariff.Comparison.Domain.Interfaces.Evaluation.Response;
using Tariff.Comparison.Domain.Model;
using Xunit;
namespace Tariff.Comparison.Evaluator.Test;

public class PackageTariffEvaluatorTest
{
    private readonly Product _p;
    private readonly PackageTariffEvaluator _sut;
    public PackageTariffEvaluatorTest()
    {
        ProductTariffDetails details = new(800, 30, 4000);
        _p = new("Product", (int)TariffType.Package, details);
        _sut = new();
    }

    [Fact]
    public async void ShouldReturnFalseIfAnnualConsumptionIsNegative()
    {        
        EvaluationRequest request = new(_p, -1);
        EvaluationResponse result = await _sut.Calculate(request);

        Assert.False(result.Successed);
    }

    [Theory]
    [InlineData([0, 800])]
    [InlineData([3500, 800])]
    [InlineData([4000, 800])]
    [InlineData([4500, 950])]
    public async void ShouldReturn(double annualConsumption, double expectedValue)
    {
        EvaluationRequest request = new(_p, annualConsumption);
        EvaluationResponse result = await _sut.Calculate(request);

        Assert.True(result.Successed);
        Assert.Equal(expectedValue, result.Cost);
    }
}