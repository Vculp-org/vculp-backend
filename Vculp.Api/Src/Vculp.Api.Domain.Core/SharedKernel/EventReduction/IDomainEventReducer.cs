using System.Collections.Generic;
using Vculp.DDD.Shared;

namespace Vculp.Api.Domain.Core.SharedKernel.EventReduction
{
    public interface IDomainEventReducer
    {
        IEnumerable<IDomainEvent> ReduceEvents(AggregateRoot aggregateRoot);
    }

    public interface IDomainEventReducer<in T>
        where T : AggregateRoot
    {
        IEnumerable<IDomainEvent> ReduceEvents(T aggregateRoot);
    }
}
