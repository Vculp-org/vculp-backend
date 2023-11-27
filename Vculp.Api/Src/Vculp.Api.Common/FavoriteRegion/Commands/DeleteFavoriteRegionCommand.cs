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
    public class DeleteFavoriteRegionCommand : IRequest<ICommandResult<bool>>
    {
        [FromRoute(Name = "favoriteRegionId")]
        public Guid FavoriteRegionId { get; set; }
    }

}
