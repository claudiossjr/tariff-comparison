using Tariff.Comparison.Domain.Enums;
using Tariff.Comparison.Domain.Exceptions;
using Tariff.Comparison.Domain.Interfaces.Evaluation.Request;
using Tariff.Comparison.Domain.Interfaces.Evaluation.Response;
using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Evaluator.Test;


[Trait("UnitTest", "EvaluatorTest")]
public class BasicTariffEvaluatorTest
{
    private readonly Product _p;
    private readonly BasicTariffEvaluator _sut;

    public BasicTariffEvaluatorTest()
    {
        ProductTariffDetails details = new(5, 22, null);
        _p = new("Product", 1, details);
        _sut = new();
    }

    [Fact]
    public async void ShouldReturnSucceedFalseIfAnnualConsumptionIsNegative()
    {        
        EvaluationRequest request = new(_p, -1);
        EvaluationResponse result = await _sut.Calculate(request);

        Assert.False(result.Successed);
    }

    [Theory]
    [InlineData([0, 60])]
    [InlineData([3500, 830])]
    [InlineData([4000, 940])]
    [InlineData([4500, 1050])]
    public async void ShouldReturn(double annualConsumption, double expectedValue)
    {
        EvaluationRequest request = new(_p, annualConsumption);
        EvaluationResponse result = await _sut.Calculate(request);

        Assert.True(result.Successed);
        Assert.Equal(expectedValue, result.Cost);
    }    
}