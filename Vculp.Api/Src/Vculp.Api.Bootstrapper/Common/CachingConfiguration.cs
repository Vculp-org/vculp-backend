using Microsoft.Extensions.DependencyInjection;
using Vculp.Api.Data.EntityFramework.Rbac.Caching;
using Vculp.Api.Domain.Interfaces.Rbac.Caching;

namespace Vculp.Api.Bootstrapper.Common
{
    public static class CachingConfiguration
    {
        public static void AddCachingComponents(this IServiceCollection services)
        {
            //ApplicationPermissionCache
            services.AddSingleton<IApplicationPermissionCache, ApplicationPermissionCache>();
        }
    }
}