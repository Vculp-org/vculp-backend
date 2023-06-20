using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;

namespace Vculp.Api.Common.Broadcast
{
    public class AzureServiceBusBroadcastQueue : IBroadcaster
    {
        private readonly ISenderClient _sender;

        public AzureServiceBusBroadcastQueue(ISenderClient sender)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }

        public async Task BroadcastAsync(IBroadcast broadcast)
        {
            if (broadcast == null)
            {
                throw new ArgumentNullException(nameof(broadcast));
            }

            var queueItem = new BroadcastQueueItem(broadcast);

            var message = new Message(JsonSerializer.SerializeToUtf8Bytes(queueItem))
            {
                ContentType = "application/json; charset=utf-8"
            };

            await _sender.SendAsync(message);
        }
    }
}
