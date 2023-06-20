using System.Collections.Generic;
using System.Threading.Tasks;
using Vculp.TransactionalOutbox.Models;

namespace Vculp.Api.Common.Outbox
{
    public interface IOutboxMessageRepository
    {
        void Add(OutboxMessage message);
        void Add(IEnumerable<OutboxMessage> messages);
        Task<IEnumerable<OutboxMessage>> GetAllUnprocessedMessagesAsync();
    }
}
