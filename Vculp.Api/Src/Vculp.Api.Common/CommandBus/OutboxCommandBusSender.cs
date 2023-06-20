using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Vculp.Api.Common.Common;
using Vculp.Api.Common.Outbox;
using Vculp.Api.Shared.Abstractions.Cqrs;

namespace Vculp.Api.Common.CommandBus
{
    public class OutboxCommandBusSender : ICommandBus
    {
        private readonly IOutboxMessageRepository _outboxMessageRepository;
        private readonly MessageContext _messageContext;

        public OutboxCommandBusSender(
            IOutboxMessageRepository outboxMessageRepository,
            MessageContext messageContext)
        {
            _outboxMessageRepository = outboxMessageRepository ?? throw new ArgumentNullException(nameof(outboxMessageRepository));
            _messageContext = messageContext ?? throw new ArgumentNullException(nameof(messageContext));
        }

        public Task SendAsync(ICommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            SendCommandsInternal(new List<ICommand> { command });

            return Task.CompletedTask;
        }

        public Task SendAsync(IEnumerable<ICommand> commands)
        {
            if (commands == null)
            {
                throw new ArgumentNullException(nameof(commands));
            }

            if (!commands.Any())
            {
                throw new ArgumentException($"{nameof(commands)} must contain at least one command.", nameof(commands));
            }

            SendCommandsInternal(commands);

            return Task.CompletedTask;
        }

        private void SendCommandsInternal(IEnumerable<ICommand> commands)
        {
            var correlationId = _messageContext.GetValueOrDefault(MessageContextKeys.CorrelationId);

            foreach (var command in commands)
            {
                var outboxMessage = new CommandOutboxMessage(command);

                if (!string.IsNullOrWhiteSpace(correlationId))
                {
                    outboxMessage.Headers[MessageContextKeys.CorrelationId] = correlationId;
                }
               
                _outboxMessageRepository.Add(outboxMessage);
            }
        }
    }
}
