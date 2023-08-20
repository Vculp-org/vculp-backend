using Microsoft.Extensions.DependencyInjection;
using Vculp.Api.Domain.FareRecommendation.Services;
using Vculp.Api.Domain.Interfaces.FareRecommendation.Services;

namespace Vculp.Api.Bootstrapper.Common
{
    public static class DomainServicesConfiguration
    {
        public static void AddDomainServicesComponents(this IServiceCollection services)
        {
            // Fare
            services.AddTransient<IFareRecommenderService, FareRecommenderService>();

        }
    }
}