using System;
using System.Collections.Generic;

using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Vculp.Api.Shared.Abstractions.Cqrs;
using static Vculp.Api.Domain.Core.Notifications.NotificationEnum;

namespace Vculp.Api.Common.Notifications.Commands
{
    public class DistributeNotificationCommand :IRequest<Common.ICommandResult>, ICommand
    {
        public DistributeNotificationCommand()
        {
            CommandId = Guid.NewGuid();
        }
        public NotificationType NotificationType { get; set; }
        public string Content { get; set; }
        public IEnumerable<Guid> Recipients { get; set; }

        [BindNever]
        public Guid CommandId { get; }
    }
}
