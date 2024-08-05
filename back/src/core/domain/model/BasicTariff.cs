using Tariff.Comparison.Domain.Enums;

namespace Tariff.Comparison.Domain.Model;

public record BasicTariff : BaseTariff
{
    public BasicTariff(string Name, TariffType Type, double BaseCost, double AdditionalKwhCost) : base(Name, Type, BaseCost, AdditionalKwhCost)
    {
    }
}
