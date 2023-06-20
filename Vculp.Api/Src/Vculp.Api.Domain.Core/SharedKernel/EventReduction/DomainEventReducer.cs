using System.Collections.Generic;
using System.Linq;
using Vculp.DDD.Shared;

namespace Vculp.Api.Domain.Core.SharedKernel.EventReduction
{
    public abstract class DomainEventReducer<T> : IDomainEventReducer<T>
        where T : AggregateRoot
    {
        public IEnumerable<IDomainEvent> ReduceEvents(T aggregateRoot)
        {
            var reducedEvents = ReduceEvents(aggregateRoot.DomainEvents);
            return reducedEvents.OrderBy(e => e.EventTime).ToList();
        }

        // protected IEnumerable<IDomainEvent> ReduceEvent<TDomainEvent>(IEnumerable<IDomainEvent> domainEvents, IDomainEventReductionStrategy reductionStrategy)
        //     where TDomainEvent : class, IDomainEvent
        // {
        //     var eventsToReduce = domainEvents.OfType<TDomainEvent>();
        //     var reducedEvents = reductionStrategy.ReduceEvents(eventsToReduce);
        //     var discardedEvents = eventsToReduce.Except(reducedEvents);
        //     return domainEvents.Except(discardedEvents);
        // }

        protected abstract IEnumerable<IDomainEvent> ReduceEvents(IEnumerable<IDomainEvent> domainEvents);
    }
}
