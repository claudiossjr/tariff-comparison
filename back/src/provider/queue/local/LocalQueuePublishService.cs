using System.Text.Json;
using Tariff.Comparison.Domain.Interfaces;
using Tariff.Comparison.Domain.Interfaces.Consumer;
using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Provider.Queue.Local;

public class LocalQueueProducerService(ILocalQueue localQueue) : IQueueProducerService
{
    private readonly ILocalQueue _localQueue = localQueue;
    public async Task Produce(Product product)
    {
        string message = JsonSerializer.Serialize(product);
        await _localQueue.Publish(message);
    }
}
