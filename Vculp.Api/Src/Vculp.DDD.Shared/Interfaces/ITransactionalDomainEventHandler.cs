namespace Vculp.DDD.Shared.Interfaces
{

    public interface ITransactionalDomainEventHandler<in T> where T : IDomainEvent
    {
        Task HandleAsync(T domainEvent);
    }

}

