using System.ComponentModel;

namespace Tariff.Comparison.Domain.Enums;

public enum TariffType
{
    [Description("Desconhecido")]
    Unkonwn = 0,
    [Description("Basic Tariff")]
    Basic = 1,
    [Description("Package Tariff")]
    Package = 2,
}
