using Tariff.Comparison.Domain.Interfaces.Repository;
using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Data.Local.Repositories;

public class LocalSaveProductRepository (ProductsContext context) : ISaveProductRepository
{
    private readonly ProductsContext _context = context;

    public async Task<Product> Save(Product product)
    {
        if (_context.Products.Contains(product))
        {
            _context.Products.Update(product);
        }
        else 
        {
            _context.Products.Add(product);
        }
        await _context.SaveChangesAsync();
        return product;
    }
}
