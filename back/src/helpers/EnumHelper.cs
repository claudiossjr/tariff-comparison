using System.ComponentModel;
using System.Reflection;

namespace Tariff.Comparison.Helpers;

public static class EnumHelper
{
    public static string GetEnumDescription(Enum value)
{
    FieldInfo? fi = value.GetType().GetField(value.ToString());

    DescriptionAttribute[]? attributes = fi?.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

    if (attributes != null && attributes.Length != 0)
    {
        return attributes.First().Description;
    }

    return "";
}
}
