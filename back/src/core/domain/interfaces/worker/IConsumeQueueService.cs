using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Domain.Interfaces.Worker;

public interface IQueueConsumerService
{
    ValueTask<Product?> Consume();
}