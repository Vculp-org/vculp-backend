using System;
using Geocoding;
using Geocoding.Microsoft;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Vculp.Api.Bootstrapper.Common
{
    public static class GeocoderConfiguration
    {
        public static void BootstrapGeocoder(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            services.AddTransient<IGeocoder, BingMapsGeocoder>(f => new BingMapsGeocoder(configuration.GetValue<string>("maps-key")));
        }
    }
}
