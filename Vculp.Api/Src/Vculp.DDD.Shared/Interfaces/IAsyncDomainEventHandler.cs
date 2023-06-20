namespace Vculp.DDD.Shared.Interfaces;

public interface IAsyncDomainEventHandler<in T> where T : IDomainEvent
{
    Task HandleAsync (T domainEvent);
}
