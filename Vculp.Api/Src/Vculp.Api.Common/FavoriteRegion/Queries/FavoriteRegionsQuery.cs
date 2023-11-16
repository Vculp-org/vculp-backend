using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.FavoriteRegion.Responses;
using Vculp.Api.Shared.Abstractions.Paging;

namespace Vculp.Api.Common.FavoriteRegion.Queries
{
    public class FavoriteRegionsQuery : PagedResourceParameters, IRequest<IPagedList<FavoriteRegionResponse>>
    {
        public FavoriteRegionsQuery() : base(10,20)
        {
        }

        [FromQuery]
        public Guid? UserId { get; set; }
    }
}
