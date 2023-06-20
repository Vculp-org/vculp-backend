namespace Vculp.DDD.Shared.Interfaces;

public interface IAsyncDomainEventDispatcher
{
    Task DispatchAsync (IEnumerable<IDomainEvent> events);
}