using System.Threading.Channels;
using Microsoft.Extensions.Logging;
using Vculp.TransactionalOutbox.Models;

namespace Vculp.TransactionalOutbox.Triggers;

public class OutboxProcessingTriggerChannel : IOutboxProcessingTrigger
{
    private readonly Channel<OutboxProcessingTriggerInfo> _channel;

    private readonly ILogger<OutboxProcessingTriggerChannel> _logger;

    public ChannelReader<OutboxProcessingTriggerInfo> Reader => _channel.Reader;

    public OutboxProcessingTriggerChannel (BoundedChannelOptions options, ILogger<OutboxProcessingTriggerChannel> logger)
    {
        if (options == null) {
            throw new ArgumentNullException ("options");
        }
        _channel = Channel.CreateBounded<OutboxProcessingTriggerInfo> (options);
        _logger = logger ?? throw new ArgumentNullException ("logger");
    }

    public void Complete ()
    {
        _channel.Writer.TryComplete ();
    }

    public Task TriggerAsync (OutboxProcessingTriggerInfo triggerInfo)
    {
        if (triggerInfo == null) {
            throw new ArgumentNullException ("triggerInfo");
        }
        if (!_channel.Writer.TryWrite (triggerInfo)) {
            _logger.LogWarning ("The trigger could not be added to the channel. Ensure that the channel has sufficient capacity.");
        }
        return Task.CompletedTask;
    }
}