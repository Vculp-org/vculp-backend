namespace Vculp.DDD.Shared.Interfaces;

public interface ITransactionalDomainEventDispatcher
{
    Task DispatchAsync (IEnumerable<IDomainEvent> events);
}
