using System;

using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Vculp.Api.Shared.Abstractions.Cqrs;

namespace Vculp.Api.Common.Notifications.Commands
{
    public class SendSmsMessageCommand : IRequest<Common.ICommandResult>, ICommand
    {
        public SendSmsMessageCommand()
        {
            CommandId = Guid.NewGuid();
        }

        public string MessageText { get; set; }
        public string Recipient { get; set; }
        public string ScheduleDate { get; set; }

        [BindNever]
        public Guid CommandId { get; private set; }
    }
}