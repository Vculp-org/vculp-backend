using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vculp.Api.Bootstrapper.Common;
using Vculp.Api.Common.LinkGeneration;

namespace Vculp.Api
{
    public static class LinkGenerationConfiguration
    {
        public static void ConfigureLinkGeneration(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            services.AddOptions<RoutingOptions>()
                .Bind(configuration.GetSection("Routing"))
                .Validate(config =>
                {
                    return config.BaseUrl != null && config.BaseUrl.IsAbsoluteUri;
                }, "The BaseUrl property must be set to an absolute url.")
                .ValidateEagerly();

            services.AddTransient<ILinkGenerator, LinkGenerationHelper>();
        }
    }
}
