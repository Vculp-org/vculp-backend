using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Vculp.Api.Common.Common;
using Vculp.Api.Shared.Abstractions.Cqrs;

namespace Vculp.Api.Common.CommandBus
{
    public class AzureServiceBusCommandBusSender : ICommandBus
    {
        private readonly ISenderClient _sender;
        private readonly MessageContext _messageContext;

        public AzureServiceBusCommandBusSender(
            ISenderClient sender,
            MessageContext messageContext)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
            _messageContext = messageContext ?? throw new ArgumentNullException(nameof(messageContext));
        }

        public async Task SendAsync(ICommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var commandBusCommand = new CommandBusCommand(
                command.GetType().FullName,
                command);

            var serviceBusMessage = new Message(JsonSerializer.SerializeToUtf8Bytes(commandBusCommand))
            {
                ContentType = "application/json; charset=utf-8",
                MessageId = command.CommandId.ToString(),
                CorrelationId = _messageContext.GetValueOrDefault(MessageContextKeys.CorrelationId)
            };

            await SendServiceBusMessages(new List<Message> { serviceBusMessage }).ConfigureAwait(false);
        }

        public async Task SendAsync(IEnumerable<ICommand> commands)
        {
            if (commands == null)
            {
                throw new ArgumentNullException(nameof(commands));
            }

            if (!commands.Any())
            {
                throw new ArgumentException($"{nameof(commands)} must contain at least one command.", nameof(commands));
            }

            var serviceBusMessages = new List<Message>();

            foreach (var command in commands)
            {
                var commandBusCommand = new CommandBusCommand(
                    command.GetType().FullName,
                    command);

                var serviceBusMessage = new Message(JsonSerializer.SerializeToUtf8Bytes(commandBusCommand))
                {
                    ContentType = "application/json; charset=utf-8",
                    MessageId = command.CommandId.ToString(),
                    CorrelationId = _messageContext.GetValueOrDefault(MessageContextKeys.CorrelationId)
                };

                serviceBusMessages.Add(serviceBusMessage);
            }

            await SendServiceBusMessages(serviceBusMessages).ConfigureAwait(false);
        }

        private async Task SendServiceBusMessages(IList<Message> serviceBusMessages)
        {
            await _sender.SendAsync(serviceBusMessages).ConfigureAwait(false);
        }
    }
}
