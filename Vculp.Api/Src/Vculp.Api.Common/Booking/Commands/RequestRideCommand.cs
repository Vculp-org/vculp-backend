using System;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Vculp.Api.Common.User.Responses;
using Vculp.Api.Shared.Abstractions.Cqrs;

namespace Vculp.Api.Common.Location.Commands
{
    public class RequestRideCommand : IRequest<Common.ICommandResult>, ICommand
    {
        public RequestRideCommand()
        {
            CommandId = Guid.NewGuid();
        }

        public Guid UserId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        [BindNever] public Guid CommandId { get; }
    }
}