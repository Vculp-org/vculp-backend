using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Vculp.Api.Common.GoogleMaps.Configs;
using Vculp.Api.Domain.Interfaces.GoogleMaps;


namespace Vculp.Api.Bootstrapper.GoogleMaps;

public static class GoogleMapsModuleConfiguration
{
    public static void ConfigureGoogleMapsModule(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration == null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }

        services.Configure<GoogleMapsConfiguration>(configuration.GetSection("GoogleMapsConfiguration"));

        ConfigureGoogleMapsRefitClient(services, configuration);
    }

    public static void ConfigureGoogleMapsRefitClient(this IServiceCollection services, IConfiguration configuration)
    {
        //var googleMapsConfig = services.
        var googleMapsConfig = configuration.GetSection("GoogleMapsConfiguration")
            .Get<GoogleMapsConfiguration>();
        services.AddRefitClient<IDistanceMatrixApi>().ConfigureHttpClient(c =>
                c.BaseAddress = new Uri(googleMapsConfig.BaseUrl))
            .AddHttpMessageHandler<HttpLoggingHandler>();;
    }
}