using Vculp.TransactionalOutbox.Models;

namespace Vculp.TransactionalOutbox.Routing;

public interface IOutboxMessageRouter<in T> where T : OutboxMessage
{
    Task RouteMessageAsync (T message);
}
