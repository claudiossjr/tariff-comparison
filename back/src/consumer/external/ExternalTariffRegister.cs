using System.Text.Json;
using Tariff.Comparison.Domain.Interfaces.Consumer;
using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.External.Consumer;

public class ExternalTariffRegister : IExternalTariffRegister
{
    private readonly IPublishQueueService _publishQueueService;
    
    public ExternalTariffRegister(IPublishQueueService publishQueueService)
    {
        _publishQueueService = publishQueueService;
    }

    public async Task<bool> Register(Product product)
    {
        await _publishQueueService.Publish(product);
        return true;
    }
}
