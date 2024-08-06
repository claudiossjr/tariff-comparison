using Tariff.Comparison.Domain.Interfaces.Consumer;
using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.External.Consumer;

public class ExternalTariffRegister : IExternalTariffRegister
{
    public async Task<bool> Register(Product product)
    {
        await Task.Yield();
        throw new NotImplementedException();
    }
}
