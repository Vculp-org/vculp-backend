using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FluentValidation;
using Microsoft.Extensions.Logging;
using Vculp.Api.Shared.Abstractions.Cqrs;

namespace Vculp.Api.Common.CommandBus
{
    public class CommandValidatingCommandBus : ICommandBus
    {
        private readonly ICommandBus _commandBus;
        private readonly IValidatorFactory _validatorFactory;
        private readonly ILogger<CommandValidatingCommandBus> _logger;

        public CommandValidatingCommandBus(
            IValidatorFactory validatorFactory,
            ILogger<CommandValidatingCommandBus> logger,
            ICommandBus commandBus)
        {
            _validatorFactory = validatorFactory ?? throw new ArgumentNullException(nameof(validatorFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _commandBus = commandBus ?? throw new ArgumentNullException(nameof(commandBus));
        }

        public async Task SendAsync(ICommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            ValidateCommand(command);

            await _commandBus.SendAsync(command);
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
                ValidateCommand(command);
            }

            await _commandBus.SendAsync(commands);
        }

        private void ValidateCommand(ICommand command)
        {
            var validator = _validatorFactory.GetValidator(command.GetType());

            if (validator != null)
            {
                var validationResult = validator.Validate(new ValidationContext<object>(command));

                if (!validationResult.IsValid)
                {
                    _logger.LogError("Validation failed for command of type {commandType}", command.GetType().FullName);

                    foreach (var error in validationResult.Errors)
                    {
                        _logger.LogError("Property Name: {propertyName}. Error: {error}", error.PropertyName, error.ErrorMessage);
                    }

                    throw new ArgumentException("Validation failure. Validation of the command failed", nameof(command));
                }

                _logger.LogInformation("Command validation completed successfully.");
            }
            else
            {
                _logger.LogInformation("No validator found for command type {commandType}", command.GetType().FullName);
            }
        }
    }
}
