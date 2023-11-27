using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vculp.Api.Common.FavoriteRegion.Responses;

namespace Vculp.Api.Common.FavoriteRegion.Queries
{
    public class FavoriteRegionQuery : IRequest<FavoriteRegionResponse>
    {
        [FromRoute]
        public Guid FavoriteRegionId { get; set; }
    }
}
