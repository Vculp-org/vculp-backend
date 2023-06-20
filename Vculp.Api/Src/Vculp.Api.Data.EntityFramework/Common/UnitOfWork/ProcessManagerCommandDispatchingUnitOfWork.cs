using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Outbox;
using Vculp.Api.Domain.Interfaces.Common;

namespace Vculp.Api.Data.EntityFramework.Common.UnitOfWork
{
    public class ProcessManagerCommandDispatchingUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private readonly MessageContext _messageContext;
        private readonly IOutboxMessageRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ProcessManagerCommandDispatchingUnitOfWork(
            DbContext dbcontext,
            MessageContext messageContext,
            IOutboxMessageRepository repository,
            IUnitOfWork unitOfWork)
        {
            _dbContext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
            _messageContext = messageContext ?? throw new ArgumentNullException(nameof(messageContext));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task SaveChangesAsync()
        {
            await _unitOfWork.SaveChangesAsync();

            var processManagers = _dbContext.ChangeTracker.Entries<ProcessManager>().Select(e => e.Entity).ToList();
            var commandsToSend = processManagers.SelectMany(pm => pm.CommandsToSend);

            var correlationId = _messageContext.GetValueOrDefault(MessageContextKeys.CorrelationId);

            foreach (var command in commandsToSend)
            {
                var outboxMessage = new CommandOutboxMessage(command);

                if (!string.IsNullOrWhiteSpace(correlationId))
                {
                    outboxMessage.Headers[MessageContextKeys.CorrelationId] = correlationId;
                }

                _repository.Add(outboxMessage);
            }

            foreach (var processManager in processManagers)
            {
                processManager.ClearCommands();
            }
        }
    }
}
