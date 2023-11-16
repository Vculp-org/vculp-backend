using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vculp.Api.Common.FavoriteRegion.Mappers;
using Vculp.Api.Common.FavoriteRegion.Queries;
using Vculp.Api.Common.FavoriteRegion.Responses;
using Vculp.Api.Common.User.Mappers;
using Vculp.Api.Common.User.Queries;
using Vculp.Api.Common.User.Responses;
using Vculp.Api.Data.EntityFramework.Common;

namespace Vculp.Api.Data.EntityFramework.FavoriteRegion.QueryHandlers
{
    public class FavoriteRegionQueryHandler : QueryHandler, IRequestHandler<FavoriteRegionQuery, FavoriteRegionResponse>
    {
        public FavoriteRegionQueryHandler(CoreContext context) : base(context)
        {
        }

        public async Task<FavoriteRegionResponse> Handle(FavoriteRegionQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var region = await Context.FavoriteRegions.SingleOrDefaultAsync(x => x.Id == request.FavoriteRegionId, cancellationToken: cancellationToken);

            if (region == null)
            {
                return null;
            }

            var regionResponse = FavoriteRegionMapper.MapToFavoriteRegionResponse(region);
            return regionResponse;
        }
    }
}
