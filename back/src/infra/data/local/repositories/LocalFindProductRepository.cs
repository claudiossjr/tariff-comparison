using System.Linq;
using Tariff.Comparison.Domain.Interfaces.Repository;
using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Data.Local.Repositories;

public class LocalFindProductsRepository(ProductsContext context) : IFindProductsRepository
{
    private readonly ProductsContext _context = context;

    public IQueryable<Product> Find()
    {
        return _context.Set<Product>();
    }
}
