using Tariff.Comparison.Domain.Enums;
using Tariff.Comparison.Helpers;

namespace Tariff.Comparison.Domain.Model;

public class Product
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

    public required string Name { get; set; }
    public required int RawType { get; set; }
    public required ProductTariffDetails TariffDetails { get; set; }
}
