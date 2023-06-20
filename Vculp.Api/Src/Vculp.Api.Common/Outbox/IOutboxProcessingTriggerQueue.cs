using System.Threading.Tasks;
using Vculp.TransactionalOutbox.Models;

namespace Vculp.Api.Common.Outbox
{
    public interface IOutboxProcessingTriggerQueue
    {
        Task QueueProcessingTriggerAsync(OutboxProcessingTriggerInfo triggerInfo);
    }
}
