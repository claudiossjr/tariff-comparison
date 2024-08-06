using Tariff.Comparison.Domain.Enums;
using Tariff.Comparison.Helpers;

namespace Tariff.Comparison.Domain.Model;

public record Product(string Name, int RawType, ProductTariffDetails TariffDetails)
{
    public TariffType Type
    {
        get {
           return (TariffType)RawType;
        }
    }

    public string TypeDescription 
    {
        get {
            return EnumHelper.GetEnumDescription(Type);
        }
    }
}
