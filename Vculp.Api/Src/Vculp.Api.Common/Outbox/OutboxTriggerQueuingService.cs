using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Vculp.TransactionalOutbox.Models;
using Vculp.TransactionalOutbox.Triggers;

namespace Vculp.Api.Common.Outbox
{
    public class OutboxTriggerQueuingService : BackgroundService
    {
        private readonly OutboxProcessingTriggerChannel _channel;
        private readonly IOutboxProcessingTriggerQueue _outboxProcessingQueue;
        private readonly ILogger<OutboxTriggerQueuingService> _logger;

        public OutboxTriggerQueuingService(
            OutboxProcessingTriggerChannel channel,
            IOutboxProcessingTriggerQueue outboxProcessingQueue,
            ILogger<OutboxTriggerQueuingService> logger)
        {
            _channel = channel ?? throw new ArgumentNullException(nameof(channel));
            _outboxProcessingQueue = outboxProcessingQueue ?? throw new ArgumentNullException(nameof(outboxProcessingQueue));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (await _channel.Reader.WaitToReadAsync())
            {
                if (_channel.Reader.TryRead(out OutboxProcessingTriggerInfo triggerInfo))
                {
                    try
                    {
                        await _outboxProcessingQueue.QueueProcessingTriggerAsync(triggerInfo);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "An unhandled exception occurred whilst processing an outbox trigger.");
                    }
                }
            }
        }
    }
}
