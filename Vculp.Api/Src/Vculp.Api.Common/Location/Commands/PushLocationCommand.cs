using System;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Vculp.Api.Common.User.Responses;
using Vculp.Api.Shared.Abstractions.Cqrs;

namespace Vculp.Api.Common.Location.Commands
{
    public class PushLocationCommand : IRequest<Common.ICommandResult>, ICommand
    {
        public PushLocationCommand()
        {
            CommandId = Guid.NewGuid();
        }

        public Guid UserId { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        [BindNever] public Guid CommandId { get; }
    }
}