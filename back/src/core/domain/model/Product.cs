using Tariff.Comparison.Domain.Enums;

namespace Tariff.Comparison.Domain.Model;

public record Product(string Name, int RawType, ProductTariffDetails TariffDetails)
{
    public TariffType Type
    {
        get {
           return (TariffType)RawType;
        }
    }
}
