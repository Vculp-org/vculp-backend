using System;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Vculp.Api.Common.Booking.Responses;
using Vculp.Api.Common.Common;
using Vculp.Api.Domain.Core.SharedKernel;
using Vculp.Api.Shared.Abstractions.Cqrs;

namespace Vculp.Api.Common.Booking.Commands
{
    public class RequestRideCommand : ICommand, IRequest<ICommandResult<RequestRideCommandResponse>>
    {
        public RequestRideCommand()
        {
            CommandId = Guid.NewGuid();
        }

        public decimal FromLatitude { get; set; }
        public decimal FromLongitude { get; set; }
        public decimal ToLatitude { get; set; }
        public decimal ToLongitude { get; set; }
        public SharedEnums.VehicleType VehicleType { get; set; }
        public decimal RequestedFare { get; set; }

        [BindNever] public Guid CommandId { get; }
    }
}