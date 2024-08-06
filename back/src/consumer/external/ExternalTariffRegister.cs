using System.Text.Json;
using Tariff.Comparison.Domain.Interfaces.Consumer;
using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.External.Consumer;

public class ExternalTariffRegister(IQueueProducerService queueProducerService) : IExternalTariffRegister
{
    private readonly IQueueProducerService _queueProducerService = queueProducerService;

    public async Task<bool> Register(Product product)
    {
        await _queueProducerService.Produce(product);
        return true;
    }
}
