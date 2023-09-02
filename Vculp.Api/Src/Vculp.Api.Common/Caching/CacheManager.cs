using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Vculp.Api.Common.Serializer;

namespace Vculp.Api.Common.Caching;

public class CacheManager : ICacheManager
{
    private readonly IDistributedCache _distributedCache;
    private readonly IMsgPackSerializer _msgPackSerializer;

    public CacheManager(IDistributedCache distributedCache, IMsgPackSerializer msgPackSerializer)
    {
        _distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));
        _msgPackSerializer = msgPackSerializer ?? throw new ArgumentNullException(nameof(msgPackSerializer));
    }

    public T Get<T>(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException($"{nameof(key)} cannot be an empty name", nameof(key));
        }

        var bytes = _distributedCache.Get(key);
        return _msgPackSerializer.Deserialize<T>(bytes);
    }

    public async Task<T> GetAsync<T>(string key,
        CancellationToken token = default(CancellationToken))
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException($"{nameof(key)} cannot be an empty name", nameof(key));
        }

        var bytes = await _distributedCache.GetAsync(key, token);
        return _msgPackSerializer.Deserialize<T>(bytes);
    }

    public void Set<T>(string key, T value, DistributedCacheEntryOptions options)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException($"{nameof(key)} cannot be an empty name", nameof(key));
        }

        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        var serializeValue =_msgPackSerializer.Serialize(value);

        _distributedCache.Set(key, serializeValue, options);
    }

    public async Task SetAsync<T>(string key, T value, DistributedCacheEntryOptions options,
        CancellationToken token = default(CancellationToken))
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException($"{nameof(key)} cannot be an empty name", nameof(key));
        }

        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }
        
        var serializeValue =_msgPackSerializer.Serialize(value);
        await _distributedCache.SetAsync(key, serializeValue, options, token);
    }

    public void Refresh(string key)
    {
        _distributedCache.Refresh(key);
    }

    public async Task RefreshAsync(string key, CancellationToken token = default(CancellationToken))
    {
        await _distributedCache.RefreshAsync(key, token);
    }

    public void Remove(string key)
    {
        _distributedCache.Remove(key);
    }

    public async Task RemoveAsync(string key, CancellationToken token = default(CancellationToken))
    {
        await _distributedCache.RemoveAsync(key, token);
    }

    public DistributedCacheEntryOptions GetDefaultOptions()
    {
        return Get30MinSlidingOptions();
    }
    public DistributedCacheEntryOptions Get30MinSlidingOptions()
    {
        var options = new DistributedCacheEntryOptions()
        {
            SlidingExpiration = new TimeSpan(0, 30, 0)
        };
        return options;
    }
}