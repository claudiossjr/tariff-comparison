using Tariff.Comparison.Domain.Enums;
using Tariff.Comparison.Domain.Interfaces.Products;
using Tariff.Comparison.Domain.Interfaces.Repository;

namespace Tariff.Comparison.Services;

public class FindCalculableProductsNamesServices(IFindProductsRepository findProductsRepository) : IFindCalculableProductsNamesService
{
    private readonly IFindProductsRepository _findProductsRepository = findProductsRepository;
    public async Task<IEnumerable<string>> FindAsync()
    {
        await Task.Yield();
        IList<TariffType> tariffTypes = Enum.GetValues<TariffType>().Where(t => t != TariffType.Unkonwn).ToList();
        return [.. _findProductsRepository.Find().Where(products => tariffTypes.Contains(products.Type)).Select(products => products.Name)];
    }
}
