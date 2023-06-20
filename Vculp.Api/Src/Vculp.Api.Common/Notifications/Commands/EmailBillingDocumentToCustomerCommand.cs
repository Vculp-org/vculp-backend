using System;

using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Vculp.Api.Shared.Abstractions.Cqrs;

namespace Vculp.Api.Common.Notifications.Commands
{
    public class EmailBillingDocumentToCustomerCommand : IRequest<Common.ICommandResult>, ICommand
    {
        public EmailBillingDocumentToCustomerCommand()
        {
            CommandId = Guid.NewGuid();
        }

        [BindNever]
        public Guid CommandId { get; private set; }
        public string RecipientEmail { get; set; }
        public string BillingDocumentType { get; set; }
        public int BillingDocumentNumber { get; set; }
        public Guid BillingDocumentFileId { get; set; }


    }
}