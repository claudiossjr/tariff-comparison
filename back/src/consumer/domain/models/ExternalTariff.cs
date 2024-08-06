namespace Tariff.Comparison.Consumer.Domain.Models;

public record ExternalTariff(string Name, int Type, double BaseCost, double AdditionalKwhCost, double? IncludedKwh);