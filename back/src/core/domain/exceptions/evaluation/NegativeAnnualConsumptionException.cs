namespace Tariff.Comparison.Domain.Exceptions;

public class NegativeAnnualConsumptionException(double annualConsumption) : Exception($"Consumption negative not allowed with value [{annualConsumption}]")
{
}