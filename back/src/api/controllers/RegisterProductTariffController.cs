using Microsoft.AspNetCore.Mvc;
using Tariff.Comparison.Consumer.Domain.Interfaces.Adapters;
using Tariff.Comparison.Consumer.Domain.Models;
using Tariff.Comparison.Domain.Interfaces.Consumer;
using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Api.Controllers;

public static class RegisterProductTariffController
{
    public static async Task<IResult> RegisterProductAsync([FromBody] ExternalTariff tariff, [FromServices] IServiceProvider serviceProvider)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        IExternalProductConverter converter = scope.ServiceProvider.GetRequiredService<IExternalProductConverter>();
        IExternalTariffRegister register = scope.ServiceProvider.GetRequiredService<IExternalTariffRegister>();
        Product product = await converter.ConvertAsync(tariff);
        await register.Register(product);
        return Results.Created();
    }

    public static async Task<IResult> RegisterProductBatchAsync([FromBody] IEnumerable<ExternalTariff> tariffs, [FromServices] IServiceProvider serviceProvider)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        IExternalProductConverter converter = scope.ServiceProvider.GetRequiredService<IExternalProductConverter>();
        IExternalTariffRegister register = scope.ServiceProvider.GetRequiredService<IExternalTariffRegister>();
        foreach (ExternalTariff tariff in tariffs)
        {
            Product product = await converter.ConvertAsync(tariff);
            await register.Register(product);
        }
        return Results.Created();
    }
}