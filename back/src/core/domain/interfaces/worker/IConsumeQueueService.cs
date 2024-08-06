using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Domain.Interfaces.Worker;

public interface IQueueConsumerService
{
    IAsyncEnumerable<Product?> Consume();
}