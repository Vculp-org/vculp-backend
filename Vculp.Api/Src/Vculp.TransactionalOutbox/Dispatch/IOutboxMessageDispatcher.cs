using Vculp.TransactionalOutbox.Models;

namespace Vculp.TransactionalOutbox.Dispatch;


public interface IOutboxMessageDispatcher
{
    Task DispatchMessageAsync (OutboxMessage message);
}
