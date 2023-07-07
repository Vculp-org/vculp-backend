using Microsoft.Extensions.DependencyInjection;

namespace Vculp.Api.Bootstrapper.Common
{
    public static class CachingConfiguration
    {
        public static void AddCachingComponents(this IServiceCollection services)
        {
            //ApplicationPermissionCache
            //ervices.AddSingleton<IApplicationPermissionCache, ApplicationPermissionCache>();
        }
    }
}