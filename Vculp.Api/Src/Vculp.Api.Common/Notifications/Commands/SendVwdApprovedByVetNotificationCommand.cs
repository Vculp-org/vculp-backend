using System;

using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Vculp.Api.Shared.Abstractions.Cqrs;

namespace Vculp.Api.Common.Notifications.Commands
{
    public class SendVwdApprovedByVetNotificationCommand : IRequest<Common.ICommandResult>, ICommand
    {
        public SendVwdApprovedByVetNotificationCommand()
        {
            CommandId = Guid.NewGuid();
        }

        public int ScriptNumber { get; set; }
        public Guid VwdId { get; set; }
        public string VwdEmailAddress { get; set; }
        public string ProductCode { get; set; }
        public string MedicationCode { get; set; }
        public string StartDate { get; set; }
        [BindNever]
        public Guid CommandId { get; private set; }

    }
}