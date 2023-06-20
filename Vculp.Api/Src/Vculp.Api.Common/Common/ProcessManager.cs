using System;
using System.Collections.Generic;
using System.Linq;
using Vculp.Api.Shared.Abstractions.Cqrs;


namespace Vculp.Api.Common.Common
{
    public abstract class ProcessManager
    {
        private List<ICommand> _commandsToSend = new List<ICommand>();

        public IEnumerable<ICommand> CommandsToSend => _commandsToSend.ToList();

        protected void SendCommand(ICommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            _commandsToSend.Add(command);
        }

        public void ClearCommands()
        {
            _commandsToSend.Clear();
        }
    }
}
