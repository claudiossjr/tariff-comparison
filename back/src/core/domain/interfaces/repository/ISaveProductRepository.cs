using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Domain.Interfaces.Repository;

public interface ISaveProductRepository 
{
    Task<Product> Save(Product product);
}