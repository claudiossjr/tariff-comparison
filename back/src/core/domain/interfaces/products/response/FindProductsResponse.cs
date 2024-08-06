namespace Tariff.Comparison.Domain.Interfaces.Products.Response;

public record FindProductsResponse(IEnumerable<FindProductResponse> Products);