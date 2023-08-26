using Microsoft.Extensions.DependencyInjection;
using Vculp.Api.Common.Caching;

namespace Vculp.Api.Bootstrapper.Common;

public static class CachingConfigurations
{
    public static void AddCachingConfiguration(this IServiceCollection services)
    {
        services.AddDistributedMemoryCache();
        services.AddScoped<ICacheManager, CacheManager>();
    }
}