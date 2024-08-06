using Tariff.Comparison.Domain.Enums;
using Tariff.Comparison.Domain.Interfaces.Evaluation.Request;
using Tariff.Comparison.Domain.Interfaces.Evaluation.Response;
using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Evaluator.Test;

public class EvaluatorFacadeTest
{
    EvaluatorFacade _sut;

    public EvaluatorFacadeTest()
    {
        _sut = new(new EvaluationFactory());
    }

    [Theory]
    [InlineData([0])]
    [InlineData([1])]
    [InlineData([2])]
    public async void ShouldReturnSuccessedFalseWhenAnnualConsumptionNegative(int rawType)
    {
        Product p = new("name", rawType, new ProductTariffDetails(1, 1, 1));
        EvaluationRequest request = new(p, -1);

        EvaluationResponse response = await _sut.CalculateAsync(request);

        Assert.False(response.Successed);
        
    }

    [Theory]
    [InlineData([0, false])]
    [InlineData([1, true])]
    [InlineData([2, true])]
    [InlineData([3, false])]
    public async void ShouldReturnSuccessedTrueWhenAnnualConsumptionNegative(int rawType, bool expected)
    {
        Product p = new("name", rawType, new ProductTariffDetails(1, 1, 1));
        EvaluationRequest request = new(p, 10);
        EvaluationResponse response = await _sut.CalculateAsync(request);
        Assert.Equal(expected, response.Successed);
        
    }
}