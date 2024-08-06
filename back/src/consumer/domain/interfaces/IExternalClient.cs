using Tariff.Comparison.Consumer.Domain.Models;

namespace Tariff.Comparison.Consumer.Domain.Interfaces;

public interface IExternalClient
{
    Task<IEnumerable<ExternalTariff>> GetProductsTariffs();
}
