using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Vculp.TransactionalOutbox.Models;

namespace Vculp.Api.Common.Outbox
{
    public class AzureServiceBusOutboxProcessingTriggerQueue : IOutboxProcessingTriggerQueue
    {
        private readonly ISenderClient _messageSender;

        public AzureServiceBusOutboxProcessingTriggerQueue(ISenderClient messageSender)
        {
            _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
        }

        public async Task QueueProcessingTriggerAsync(OutboxProcessingTriggerInfo triggerInfo)
        {
            if (triggerInfo == null)
            {
                throw new ArgumentNullException(nameof(triggerInfo));
            }

            var messageBody = JsonSerializer.SerializeToUtf8Bytes(triggerInfo);

            var message = new Message(messageBody);
            message.ContentType = "application/json; charset=utf-8";

            await _messageSender.SendAsync(message);
        }
    }
}
