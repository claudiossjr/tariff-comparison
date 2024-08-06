using Tariff.Comparison.Consumer.Domain.Interfaces;
using Tariff.Comparison.Consumer.Domain.Models;
using Tariff.Comparison.Domain.Interfaces.Consumer;
using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.External.Consumer;

public class ExternalTariffConsumer(IExternalClient externalClient, IExternalTariffRegister externalRegister) : IExternalTariffConsumer
{
    public readonly IExternalClient _externalClient = externalClient;
    public readonly IExternalTariffRegister _externalRegister = externalRegister;

    public async Task<bool> Consume()
    {
        try {
            // Get Extenal Client
            IEnumerable<ExternalTariff> externalResult = await _externalClient.GetProductsTariffs();
            // Process Client response
            foreach (ExternalTariff tariff in externalResult)
            {
                Product product = new(tariff.Name, tariff.Type, new ProductTariffDetails(tariff.BaseCost, tariff.AdditionalKwhCost, tariff.IncludedKwh));
                // Send each item to the queue by calling ExternalTariffRegister
                await _externalRegister.Register(product);
            }
            return true;
        }
        catch(Exception)
        {
            return false;
        }

    }
}
