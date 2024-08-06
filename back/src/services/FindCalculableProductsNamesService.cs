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
        IList<int> rawTypes = Enum.GetValues<TariffType>().Where(t => t != TariffType.Unkonwn).Select(type => (int)type).ToList();
        return [.. _findProductsRepository.Find().Where(products => rawTypes.Contains(products.RawType)).Select(products => products.Name)];
    }
}
