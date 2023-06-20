using System;

namespace Vculp.Api.Common.CommandBus
{
    public class CommandBusCommand
    {
        public CommandBusCommand(
            string commandType,
            object payload)
        {
            if (string.IsNullOrWhiteSpace(commandType))
            {
                throw new ArgumentException($"{nameof(commandType)} cannot be null, empty or contain only whitespace.", nameof(commandType));
            }

            CommandType = commandType;
            Payload = payload ?? throw new ArgumentNullException(nameof(payload));
        }

        public string CommandType { get; }
        public object Payload { get; }
    }
}
