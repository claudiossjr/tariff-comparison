using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Domain.Interfaces.Consumer;

public interface IPublishQueueService
{
    Task<bool> Publish(Product product);
}