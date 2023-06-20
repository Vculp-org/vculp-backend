using System;

using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Vculp.Api.Shared.Abstractions.Cqrs;

namespace Vculp.Api.Common.Notifications.Commands
{
    public class SendGenericCustomerEmailCommand : IRequest<Common.ICommandResult>, ICommand
    {
        public SendGenericCustomerEmailCommand()
        {
            CommandId = Guid.NewGuid();
        }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string RecipientEmail { get; set; }
        public string FirstName { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }

        [BindNever]
        public Guid CommandId { get; private set; }
    }
}