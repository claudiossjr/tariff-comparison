using Tariff.Comparison.Domain.Interfaces.Cache.Request;
using Tariff.Comparison.Domain.Interfaces.Cache.Response;

namespace Tariff.Comparison.Domain.Interfaces.Cache;

public interface ICacheService
{
    Task<string?> Find(CacheRequest request);
    Task<CacheResponse<TEntity>?> Find<TEntity>(CacheRequest request) where TEntity : class;
    Task<bool> Create(string key, string value, long? expireIn = null);
    Task<string?> DecreaseValue(string key);
    Task<string?> IncreaseValue(string key);
    Task<bool> Remove(string key);
}