using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace Vculp.Api.Common.Caching;

public interface ICacheManager
{
        /// <summary>
        /// Gets a value with the given key.
        /// </summary>
        /// <param name="key">A string identifying the requested value.</param>
        /// <returns>The located value or null.</returns>
        T Get<T>(string key);

        /// <summary>
        /// Gets a value with the given key.
        /// </summary>
        /// <param name="key">A string identifying the requested value.</param>
        /// <param name="token">Optional. The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Task"/> that represents the asynchronous operation, containing the located value or null.</returns>
        Task<T> GetAsync<T>(string key, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Sets a value with the given key.
        /// </summary>
        /// <param name="key">A string identifying the requested value.</param>
        /// <param name="value">The value to set in the cache.</param>
        /// <param name="options">The cache options for the value.</param>
        void Set<T>(string key, T value, DistributedCacheEntryOptions options);

        /// <summary>
        /// Sets the value with the given key.
        /// </summary>
        /// <param name="key">A string identifying the requested value.</param>
        /// <param name="value">The value to set in the cache.</param>
        /// <param name="options">The cache options for the value.</param>
        /// <param name="token">Optional. The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
        Task SetAsync<T>(string key, T value, DistributedCacheEntryOptions options, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Refreshes a value in the cache based on its key, resetting its sliding expiration timeout (if any).
        /// </summary>
        /// <param name="key">A string identifying the requested value.</param>
        void Refresh(string key);

        /// <summary>
        /// Refreshes a value in the cache based on its key, resetting its sliding expiration timeout (if any).
        /// </summary>
        /// <param name="key">A string identifying the requested value.</param>
        /// <param name="token">Optional. The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
        Task RefreshAsync(string key, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Removes the value with the given key.
        /// </summary>
        /// <param name="key">A string identifying the requested value.</param>
        void Remove(string key);

        /// <summary>
        /// Removes the value with the given key.
        /// </summary>
        /// <param name="key">A string identifying the requested value.</param>
        /// <param name="token">Optional. The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
        Task RemoveAsync(string key, CancellationToken token = default(CancellationToken));
}