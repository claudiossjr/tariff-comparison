using Tariff.Comparison.Domain.Interfaces.Products.Request;
using Tariff.Comparison.Domain.Interfaces.Products.Response;
using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Domain.Interfaces;

public interface IFindProductsService
{
    Task<FindProductsResponse> FindProducts(FindProductsRequest request);
}
