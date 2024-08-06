using Tariff.Comparison.Consumer.Domain.Models;
using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Consumer.Domain.Interfaces.Adapters;

public interface IExternalProductConverter
{
    Task<Product> ConvertAsync(ExternalTariff extarnalProduct);
}