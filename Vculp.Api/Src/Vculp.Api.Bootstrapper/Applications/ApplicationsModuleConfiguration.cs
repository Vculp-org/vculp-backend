using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vculp.Api.Common.Applications.Configurations;

namespace Vculp.Api.Bootstrapper.Applications
{
    public static class ApplicationsModuleConfiguration
    {
        public static void ConfigureApplicationsModule(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            services.Configure<VculpUiConfiguration>(configuration.GetSection("Applications:VculpUiConfiguration"))
                .PostConfigure<VculpUiConfiguration>(options =>
                {
                    options.GoogleMapsKey = configuration.GetValue<string>("google-maps-key-ui");
                });
        }
    }
}
