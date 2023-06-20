using System;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Vculp.Api.Shared.Abstractions.Cqrs;

namespace Vculp.Api.Common.Notifications.Commands
{
    public class SendVwdCancelledByVetNotificationCommand : IRequest<Common.ICommandResult>, ICommand
    {
        public SendVwdCancelledByVetNotificationCommand()
        {
            CommandId = Guid.NewGuid();
        }
   
        public int ScriptNumber { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string ProductCode { get; set; }
        public string MedicationCode { get; set; }
        public double ScriptTonnes { get; set; }
       

        [BindNever]
        public Guid CommandId { get; private set; }
    }
}