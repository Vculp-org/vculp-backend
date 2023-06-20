using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using Vculp.Api.Shared.Abstractions.Cqrs;

namespace Vculp.Api.Common.CommandBus
{
    public class LoggingCommandBus : ICommandBus
    {
        private readonly ILogger<LoggingCommandBus> _logger;
        private readonly ICommandBus _commandBus;

        public LoggingCommandBus(
            ILogger<LoggingCommandBus> logger,
            ICommandBus commandBus)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _commandBus = commandBus ?? throw new ArgumentNullException(nameof(commandBus));
        }

        public async Task SendAsync(ICommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            _logger.LogInformation("Sending command of type {commandType} to the command bus.", command.GetType().FullName);
            await _commandBus.SendAsync(command);
            _logger.LogInformation("Command sent successfully.");
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

            foreach (var command in commands)
            {
                _logger.LogInformation("Sending command of type {commandType} to the command bus.", command.GetType().FullName);
            }

            await _commandBus.SendAsync(commands);
            
            _logger.LogInformation("{commandCount} commands sent successfully.", commands.Count());
        }
    }
}
