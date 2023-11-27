using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.FavoriteRegion.Responses;


namespace Vculp.Api.Common.FavoriteRegion.Commands
{
    public class UpdateFavoriteRegionCommand : IRequest<ICommandResult<FavoriteRegionResponse>>
    {
        [FromRoute(Name = "favoriteRegionId")]
        public Guid FavoriteRegionId { get; set; }

        [FromBody]
        public UpdateFavoriteRegionBody Body { get; set; }
    }

    public class UpdateFavoriteRegionBody
    {
        public string Name { get; set; }
        public string AreaName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Radius { get; set; }

        public bool? IsActive { get; set; }
    }
}
