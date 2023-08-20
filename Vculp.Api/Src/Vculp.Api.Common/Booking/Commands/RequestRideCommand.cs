using System;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Vculp.Api.Common.Booking.Responses;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.User.Responses;
using Vculp.Api.Shared.Abstractions.Cqrs;

namespace Vculp.Api.Common.Booking.Commands
{
    public class RequestRideCommand : IRequest<Common.ICommandResult>, ICommand, IRequest<ICommandResult<RequestRideCommandResponse>>
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