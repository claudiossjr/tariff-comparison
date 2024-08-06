using System.Text.Json;
using Tariff.Comparison.Domain.Interfaces;
using Tariff.Comparison.Domain.Interfaces.Worker;
using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Provider.Queue.Local;

public class LocalQueueConsumerService(ILocalQueue queue) : IQueueConsumerService
{
    private readonly ILocalQueue _queue = queue;
    public async IAsyncEnumerable<Product?> Consume()
    {
        string item = await _queue.Consume();
        Product? product = JsonSerializer.Deserialize<Product>(item);
        yield return product;
    }
}
