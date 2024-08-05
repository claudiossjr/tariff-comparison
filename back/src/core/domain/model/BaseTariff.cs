using Tariff.Comparison.Domain.Enums;

namespace Tariff.Comparison.Domain.Model;

public record BaseTariff(string Name, TariffType Type, double BaseCost, double AdditionalKwhCost);
