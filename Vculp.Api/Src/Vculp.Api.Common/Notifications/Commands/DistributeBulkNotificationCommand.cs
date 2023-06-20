using System;
using System.Collections.Generic;

using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Vculp.Api.Shared.Abstractions.Cqrs;
using static Vculp.Api.Domain.Core.Notifications.NotificationEnum;

namespace Vculp.Api.Common.Notifications.Commands
{
    public class DistributeBulkNotificationCommand:IRequest<Common.ICommandResult>, ICommand
    {
        public DistributeBulkNotificationCommand()
        {
            CommandId = Guid.NewGuid();
        }
        public NotificationType NotificationType { get; set; }
        public string Content { get; set; }
        public IEnumerable<string> Species { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public IEnumerable<string> Counties { get; set; }
        public bool? Organic { get; set; }


        [BindNever]
        public Guid CommandId { get; }
    }
}
