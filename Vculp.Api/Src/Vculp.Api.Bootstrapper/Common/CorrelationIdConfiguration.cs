using CorrelationId;
using CorrelationId.Abstractions;
using CorrelationId.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Vculp.Api.Bootstrapper.Common
{
    public static class CorrelationIdConfiguration
    {
        public static void AddApiCorrelationIdConfiguration(this IServiceCollection services)
        {
            services.AddDefaultCorrelationId();
        }

        public static void AddWorkerRoleCorrelationIdConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<ICorrelationContextAccessor, EmptyCorrelationIdProvider>();
        }
    }

    public class EmptyCorrelationIdProvider : ICorrelationContextAccessor
    {
        public CorrelationContext CorrelationContext
        {
            get
            {
                return new CorrelationContext("Not Set", "Not Set");
            }

            set { return; }
        }
    }
}
