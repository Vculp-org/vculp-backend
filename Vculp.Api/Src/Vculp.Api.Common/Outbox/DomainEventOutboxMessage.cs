using System.Collections.Generic;
using Vculp.DDD.Shared;
using Vculp.TransactionalOutbox.Models;

namespace Vculp.Api.Common.Outbox
{
    public class DomainEventOutboxMessage : OutboxMessage
    {
        /// <summary>
        /// Used by EF Core
        /// </summary>
        private DomainEventOutboxMessage()
            : base(payload: new { })
        {
        }

        public DomainEventOutboxMessage(IDomainEvent domainEvent)
            : base(payload: domainEvent)
        {
        }

        public IDictionary<string, string> Headers { get; private set; } = new Dictionary<string, string>();
    }
}
