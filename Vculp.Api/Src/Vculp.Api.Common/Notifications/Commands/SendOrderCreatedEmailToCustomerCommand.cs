using System;

using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Vculp.Api.Shared.Abstractions.Cqrs;

namespace Vculp.Api.Common.Notifications.Commands
{
    public class SendOrderCreatedEmailToCustomerCommand : IRequest<Common.ICommandResult>, ICommand
    {
        public SendOrderCreatedEmailToCustomerCommand()
        {
            CommandId = Guid.NewGuid();
        }

        [BindNever]
        public Guid CommandId { get; private set; }
        public int OrderNumber { get;  set; }
        public string To { get; set; }
        public string ToName { get; set; }
        public Guid OrderId { get; set; }
    }
}