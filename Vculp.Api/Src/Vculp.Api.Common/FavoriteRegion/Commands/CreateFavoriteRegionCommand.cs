using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Vculp.Api.Common.FavoriteRegion.Responses;
using Vculp.Api.Common.User.Responses;
using Vculp.Api.Shared.Abstractions.Cqrs;
using ICommand = Vculp.Api.Shared.Abstractions.Cqrs.ICommand;

namespace Vculp.Api.Common.FavoriteRegion.Commands
{
    public class CreateFavoriteRegionCommand : IRequest<Common.ICommandResult<FavoriteRegionResponse>>, ICommand
    {
        public CreateFavoriteRegionCommand()
        {
            CommandId = Guid.NewGuid();
        }

        public string Name { get; set; }
        public string AreaName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Radius { get; set; }
        public Guid UserId { get; set; }
        [BindNever] public Guid CommandId { get; }
    }
}
