using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Tariff.Comparison.Domain.Interfaces;
using Tariff.Comparison.Domain.Interfaces.Products.Request;
using Tariff.Comparison.Domain.Interfaces.Products.Response;

namespace Tariff.Comparison.Api.Controllers;


public class FindApiProductsRequest
{
    [JsonPropertyName("annualConsumption")]
    public double? AnnualConsumption { get; set; }
}

public static class FindProductsController
{
    public static async Task<IResult> FindProducatsAsync([FromQuery] double? annualConsumption, [FromServices] IServiceProvider serviceProvider)
    {
        // double? annualConsumption = request.AnnualConsumption;
        using IServiceScope scope = serviceProvider.CreateScope();
        IFindProductsService findProducts = scope.ServiceProvider.GetRequiredService<IFindProductsService>();
        if (annualConsumption == null) return Results.BadRequest();
        FindProductsResponse response = await findProducts.FindProductsAsync(new FindProductsRequest(annualConsumption!.Value));
        return Results.Json(response, statusCode: 200);
    }
}