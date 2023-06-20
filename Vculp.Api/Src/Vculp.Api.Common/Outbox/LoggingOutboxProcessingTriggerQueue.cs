using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Vculp.Extensions;
using Vculp.TransactionalOutbox.Models;

namespace Vculp.Api.Common.Outbox
{
    public class LoggingOutboxProcessingTriggerQueue : IOutboxProcessingTriggerQueue
    {
        private readonly IOutboxProcessingTriggerQueue _queue;
        private readonly ILogger<LoggingOutboxProcessingTriggerQueue> _logger;

        public LoggingOutboxProcessingTriggerQueue(
            IOutboxProcessingTriggerQueue queue,
            ILogger<LoggingOutboxProcessingTriggerQueue> logger)
        {
            _queue = queue ?? throw new ArgumentNullException(nameof(queue));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task QueueProcessingTriggerAsync(OutboxProcessingTriggerInfo triggerInfo)
        {
            if (triggerInfo == null)
            {
                throw new ArgumentNullException(nameof(triggerInfo));
            }

            _logger.LogInformation("Queuing trigger {0} triggered at {1}", triggerInfo.TriggerId, triggerInfo.TriggerTime.ConvertToIso8601DateTimeUtc());

            await _queue.QueueProcessingTriggerAsync(triggerInfo);

            _logger.LogInformation("Queued trigger {0} triggered at {1}", triggerInfo.TriggerId, triggerInfo.TriggerTime.ConvertToIso8601DateTimeUtc());
        }
    }
}
