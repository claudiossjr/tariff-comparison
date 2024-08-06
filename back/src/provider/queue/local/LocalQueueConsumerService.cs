using System.Text.Json;
using Tariff.Comparison.Domain.Interfaces;
using Tariff.Comparison.Domain.Interfaces.Worker;
using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Provider.Queue.Local;

public class LocalQueueConsumerService(ILocalQueue queue) : IQueueConsumerService
{
    private readonly ILocalQueue _queue = queue;
    public async ValueTask<Product?> Consume(CancellationToken token)
    {
        string item = await _queue.Consume(token);
        Product? product = JsonSerializer.Deserialize<Product>(item);
        return product;
    }
}
