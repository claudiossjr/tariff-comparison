using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Domain.Interfaces.Consumer;

public interface IExternalTariffConsumer
{
    Task<bool> Consume();
}