using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Domain.Interfaces.Consumer;

public interface IExternalTariffRegister
{
    Task<bool> Register(Product product);
}