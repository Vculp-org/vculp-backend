using Microsoft.Extensions.DependencyInjection;
using Vculp.Api.Common.Common;

namespace Vculp.Api.Bootstrapper.Common
{
    public static class MessageContextConfiguration
    {
        public static void ConfigurateMessageContext(this IServiceCollection services)
        {
            services.AddScoped<MessageContext>();
        }
    }
}
