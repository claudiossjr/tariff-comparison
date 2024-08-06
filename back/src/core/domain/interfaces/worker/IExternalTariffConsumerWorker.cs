using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Domain.Interfaces.Worker;

public interface IProductConsumerWorker
{
    Task HandleProduct(Product? product);
}