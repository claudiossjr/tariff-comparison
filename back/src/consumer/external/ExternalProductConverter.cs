using Tariff.Comparison.Consumer.Domain.Interfaces.Adapters;
using Tariff.Comparison.Consumer.Domain.Models;
using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.External.Converters;

public class ExternalProductConverter : IExternalProductConverter
{
    public async Task<Product> ConvertAsync(ExternalTariff tariff)
    {
        await Task.Yield();
        Product product = new(){ Name= tariff.Name,  RawType = tariff.Type, TariffDetails = new ProductTariffDetails(tariff.BaseCost, tariff.AdditionalKwhCost, tariff.IncludedKwh)};
        return product;
    }
}
