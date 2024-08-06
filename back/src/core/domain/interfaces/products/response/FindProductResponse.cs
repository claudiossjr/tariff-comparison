namespace Tariff.Comparison.Domain.Interfaces.Products.Response;

public record FindProductResponse(string ProductName, int Type, string TypeDescription, double AnnualCost);