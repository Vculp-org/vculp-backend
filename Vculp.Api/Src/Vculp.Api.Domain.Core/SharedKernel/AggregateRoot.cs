using System;
using System.Collections.Generic;
using Vculp.DDD.Shared;

namespace Vculp.Api.Domain.Core.SharedKernel
{
    public abstract class AggregateRoot : Entity
    {
        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

        protected void AddDomainEvent(IDomainEvent newEvent)
        {
            if (newEvent == null)
            {
                throw new ArgumentNullException(nameof(newEvent));
            }

            _domainEvents.Add(newEvent);
        }

        public void ClearEvents()
        {
            _domainEvents.Clear();
        }
    }
}
