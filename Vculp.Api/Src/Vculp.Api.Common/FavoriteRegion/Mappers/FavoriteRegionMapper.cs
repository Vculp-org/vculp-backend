using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.FavoriteRegion.Responses;
using Vculp.Api.Common.User.Responses;
using Vculp.Extensions;

namespace Vculp.Api.Common.FavoriteRegion.Mappers
{
    public class FavoriteRegionMapper : Mapper<Domain.Core.FavoriteRegion.FavoriteRegion>
    {
        static FavoriteRegionMapper()
        {

        }

        new public static TDestination MapTo<TDestination>(Domain.Core.FavoriteRegion.FavoriteRegion source)
       => Mapper<Domain.Core.FavoriteRegion.FavoriteRegion>.MapTo<TDestination>(source);

        public static FavoriteRegionResponse MapToFavoriteRegionResponse(Domain.Core.FavoriteRegion.FavoriteRegion favoriteRegion)
        {
            return new FavoriteRegionResponse()
            {
                AreaName = favoriteRegion.AreaName,
                Name = favoriteRegion.Name,
                Latitude = favoriteRegion.Latitude,
                Longitude = favoriteRegion.Longitude,
                Radius = favoriteRegion.Radius,
                UserId = favoriteRegion.UserId,
                FavoriteRegionId=favoriteRegion.Id
            };
        }
    }
}
