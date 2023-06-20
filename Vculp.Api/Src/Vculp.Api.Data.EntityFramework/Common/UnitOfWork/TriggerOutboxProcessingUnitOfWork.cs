using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vculp.Api.Domain.Interfaces.Common;
using Vculp.TransactionalOutbox.Models;
using Vculp.TransactionalOutbox.Triggers;

namespace Vculp.Api.Data.EntityFramework.Common.UnitOfWork
{
    public class TriggerOutboxProcessingUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private readonly IOutboxProcessingTrigger _outboxTrigger;
        private readonly IUnitOfWork _unitOfWork;

        public TriggerOutboxProcessingUnitOfWork(
            DbContext dbContext,
            IOutboxProcessingTrigger outboxTrigger,
            IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _outboxTrigger = outboxTrigger ?? throw new ArgumentNullException(nameof(outboxTrigger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task SaveChangesAsync()
        {
            await _unitOfWork.SaveChangesAsync();

            var contextContainsNewOutboxMessages = _dbContext.ChangeTracker
                                                 .Entries<OutboxMessage>()
                                                 .Any(e => e.State == EntityState.Added);

            if (contextContainsNewOutboxMessages)
            {
                await _outboxTrigger.TriggerAsync(new OutboxProcessingTriggerInfo());
            }
        }
    }
}
