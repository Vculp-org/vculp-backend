using Microsoft.Extensions.DependencyInjection;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.FavoriteRegion.Responses;
using Vculp.Api.Common.User.Responses;
using Vculp.Api.FavoriteRegion.Helpers;
using Vculp.Api.User.Helpers;

namespace Vculp.Api
{
    public static partial class ServiceCollectionExtensions
    {
        public static void BootstrapFavoriteRegionDependecies(this IServiceCollection services)
        {
            #region Link Generators

            services.AddTransient<IHateoasLinkGenerator<FavoriteRegionResponse>, FavoriteRegionLinkGenerator>();
            #endregion
        }
    }
}
