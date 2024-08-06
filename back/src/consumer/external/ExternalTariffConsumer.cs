using Tariff.Comparison.Consumer.Domain.Interfaces;
using Tariff.Comparison.Consumer.Domain.Interfaces.Adapters;
using Tariff.Comparison.Consumer.Domain.Models;
using Tariff.Comparison.Domain.Interfaces.Consumer;
using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.External.Consumer;

public class ExternalTariffConsumer(IExternalClient externalClient, IExternalTariffRegister externalRegister, IExternalProductConverter externalProductConverter) : IExternalTariffConsumer
{
    public readonly IExternalClient _externalClient = externalClient;
    public readonly IExternalTariffRegister _externalRegister = externalRegister;
    private readonly IExternalProductConverter _externalProductConverter = externalProductConverter;

    public async Task<bool> Consume()
    {
        try {
            // Get Extenal Client
            IEnumerable<ExternalTariff> externalResult = await _externalClient.GetProductsTariffs();
            // Process Client response
            foreach (ExternalTariff tariff in externalResult)
            {
                Product product = await _externalProductConverter.ConvertAsync(tariff);
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
