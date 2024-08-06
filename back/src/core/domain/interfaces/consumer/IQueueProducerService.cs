using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Domain.Interfaces.Consumer;

public interface IQueueProducerService
{
    Task Produce(Product product);
}