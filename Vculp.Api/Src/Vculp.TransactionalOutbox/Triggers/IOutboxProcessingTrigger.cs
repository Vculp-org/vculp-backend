using Vculp.TransactionalOutbox.Models;

namespace Vculp.TransactionalOutbox.Triggers;

public interface IOutboxProcessingTrigger
{
    Task TriggerAsync (OutboxProcessingTriggerInfo triggerInfo);
}