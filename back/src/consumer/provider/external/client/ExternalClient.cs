using Tariff.Comparison.Consumer.Domain.Interfaces;
using Tariff.Comparison.Consumer.Domain.Models;

namespace Tariff.Consumption.Provider.external.Client;

public class ExternalClient : IExternalClient
{
    public Task<IEnumerable<ExternalTariff>> GetProductsTariffs()
    {
        // Get on the internet
        // return a list of Tariffs
        throw new NotImplementedException();
    }
}
