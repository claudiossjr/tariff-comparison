namespace Tariff.Comparison.Domain.Model;

public record ProductTariffDetails(double BaseCost, double AdditionalKwhCost, double? IncludedKwh);