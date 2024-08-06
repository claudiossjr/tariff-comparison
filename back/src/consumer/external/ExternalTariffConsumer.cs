using Tariff.Comparison.Consumer.Domain.Interfaces;
using Tariff.Comparison.Domain.Interfaces.Consumer;
using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.External.Consumer;

public class ExternalTariffConsumer(IExternalClient externalClient) : IExternalTariffConsumer
{
    public readonly IExternalClient _externalClient = externalClient;

    public async Task<Product> Consume()
    {
        await Task.Yield();
        // Get Extenal Client
        // Process Client response
        // Send each item to the queue by calling ExternalTariffRegister
        throw new NotImplementedException();
    }
}
