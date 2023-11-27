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
using Vculp.Api.Data.EntityFramework.Extensions;
using Vculp.Api.Shared;
using Vculp.Api.Shared.Abstractions.Paging;

namespace Vculp.Api.Data.EntityFramework.FavoriteRegion.QueryHandlers
{
    public class FavoriteRegionsQueryHandler : QueryHandler, IRequestHandler<FavoriteRegionsQuery, IPagedList<FavoriteRegionResponse>>
    {
        public FavoriteRegionsQueryHandler(CoreContext context) : base(context)
        {
        }

        public async Task<IPagedList<FavoriteRegionResponse>> Handle(FavoriteRegionsQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var pageNumber = (int)request.PageNumber;
            var pageSize = (int)request.PageSize;

            var query = Context.FavoriteRegions.AsQueryable();

            if (request.UserId.HasValue)
            {
                query = query.Where(q => q.UserId == request.UserId);
            }

            var count = await query.CountAsync(cancellationToken: cancellationToken);

            var favoriteRegions = await query.OrderBy(q => q.CreationTime).Select(
                    response => FavoriteRegionMapper.MapToFavoriteRegionResponse(response))
                .PageResults(pageNumber, pageSize)
                .ToListAsync(cancellationToken: cancellationToken);
            return favoriteRegions.ToPagedList(count, pageNumber, pageSize);
        }
    }
}
