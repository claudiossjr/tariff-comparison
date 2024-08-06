using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Domain.Interfaces.Repository;

public interface IFindProductsRepository
{
    IQueryable<Product> Find();
}