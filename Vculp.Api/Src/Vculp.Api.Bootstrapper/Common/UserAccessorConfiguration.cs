using System;
using Microsoft.Extensions.DependencyInjection;

namespace Vculp.Api.Bootstrapper.Common
{
    public static class UserAccessorConfiguration
    {
        public static void ConfigureUserAccessor(this IServiceCollection services, Action<IServiceCollection> userAccessorConfiguration)
        {
            userAccessorConfiguration?.Invoke(services);
        }
    }
}
