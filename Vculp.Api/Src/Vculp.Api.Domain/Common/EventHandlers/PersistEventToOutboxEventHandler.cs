using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Outbox;
using Vculp.DDD.Shared;
using Vculp.DDD.Shared.Interfaces;

namespace Vculp.Api.Domain.Common.EventHandlers
{
    public class PersistEventToOutboxEventHandler : ITransactionalDomainEventHandler<IDomainEvent>
    {
        private readonly IOutboxMessageRepository _repository;
        private readonly ICurrentUserAccessor _userAccessor;
        private readonly MessageContext _messageContext;

        public PersistEventToOutboxEventHandler(
            IOutboxMessageRepository repository,
            ICurrentUserAccessor userAccessor,
            MessageContext messageContext)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _userAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));
            _messageContext = messageContext ?? throw new ArgumentNullException(nameof(messageContext));
        }

        public Task HandleAsync(IDomainEvent domainEvent)
        {
            var outboxMessage = new DomainEventOutboxMessage(domainEvent);

            var correlationId = _messageContext.GetValueOrDefault(MessageContextKeys.CorrelationId);

            if (!string.IsNullOrWhiteSpace(correlationId))
            {
                outboxMessage.Headers.Add(MessageContextKeys.CorrelationId, correlationId);
            }

            if (_userAccessor.UserId.HasValue)
            {
                outboxMessage.Headers.Add(MessageContextKeys.UserId, _userAccessor.UserId.ToString());
            }

            if (!string.IsNullOrWhiteSpace(_userAccessor.Name))
            {
                outboxMessage.Headers.Add(MessageContextKeys.UserDisplayName, _userAccessor.Name);
            }

            _repository.Add(outboxMessage);
            return Task.CompletedTask;
        }
    }
}
