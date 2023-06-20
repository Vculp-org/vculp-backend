using System.Collections.Generic;
using Vculp.Api.Shared.Abstractions.Cqrs;
using Vculp.TransactionalOutbox.Models;

namespace Vculp.Api.Common.Outbox
{
    public class CommandOutboxMessage : OutboxMessage
    {
        /// <summary>
        /// Used by EF Core
        /// </summary>
        private CommandOutboxMessage()
            : base(payload: new { })
        {
            Headers = new Dictionary<string, string>();
        }

        public CommandOutboxMessage(ICommand payload)
            : base(payload)
        {
            Headers = new Dictionary<string, string>();
        }

        public IDictionary<string, string> Headers { get; private set; } = new Dictionary<string, string>();
    }
}
