namespace Tariff.Comparison.Domain.Interfaces.Cache.Response;

public record CacheResponse<TEntity>(string Key, TEntity? Value) where TEntity : class;
