using System;

using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Vculp.Api.Shared.Abstractions.Cqrs;

namespace Vculp.Api.Common.Notifications.Commands
{
    public class SendOrderUnblockedEmailNotificationCommand : IRequest<Common.ICommandResult>, ICommand
    {
        public SendOrderUnblockedEmailNotificationCommand()
        {
            CommandId = Guid.NewGuid();
        }

        [BindNever]
        public Guid CommandId { get; private set; }
        public int OrderNumber { get; set; }
        public Guid OrderId { get; set; }
    }
}