using System.Text.Json;
using Tariff.Comparison.Domain.Interfaces.Cache;
using Tariff.Comparison.Domain.Interfaces.Repository;
using Tariff.Comparison.Domain.Interfaces.Worker;
using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Consumer.Worker;

public class ProductConsumerWorker (ICacheService cacheService, ISaveProductRepository saveProductRepository) : IProductConsumerWorker
{
    private readonly ISaveProductRepository _saveProductRepository = saveProductRepository;
    private readonly ICacheService _cacheService = cacheService;
    public async Task HandleProduct(Product? product)
    {
        if (product == null) return;
        // Insert on CacheService and repository
        Task[] tasks = [_cacheService.Create(product!.Name, JsonSerializer.Serialize(product)), _saveProductRepository.Save(product)];
        await Task.WhenAll(tasks);
        
    }
}
