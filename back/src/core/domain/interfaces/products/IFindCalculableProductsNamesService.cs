namespace Tariff.Comparison.Domain.Interfaces.Products;

public interface IFindCalculableProductsNamesService
{
    Task<IEnumerable<string>> FindAsync();
}