using Tariff.Comparison.Domain.Interfaces;
using Tariff.Comparison.Domain.Interfaces.Products.Request;
using Tariff.Comparison.Domain.Interfaces.Products.Response;

namespace Tariff.Comparison.Services;

public class FindProductsService : IFindProductsService
{
    public Task<FindProductsResponse> FindProducts(FindProductsRequest request)
    {
        // Get all products
        // Call evaluation for each prduct
        // Concatenate responses
        // return the result list
        throw new NotImplementedException();
    }
}
