using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vculp.Api.Domain.Interfaces.Common;
using Vculp.TransactionalOutbox.Models;
using Vculp.TransactionalOutbox.Triggers;

namespace Vculp.Api.Data.EntityFramework.Common.UnitOfWork
{
    public class TransactionWrappingUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly IOutboxProcessingTrigger _outboxTrigger;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionWrappingUnitOfWork(
            DbContext context,
            IOutboxProcessingTrigger outboxTrigger,
            IUnitOfWork unitOfWork)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _outboxTrigger = outboxTrigger ?? throw new ArgumentNullException(nameof(outboxTrigger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task SaveChangesAsync()
        {
            //Create a transaction so that the intended action and all of its side effects are treated atomically.
            //This is due to calling SaveChanges twice on the EF Context to handle domain events.

            var contextContainsNewOutboxMessages = false;

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                // We check both before and after calling save changes if we have any outbox messages
                // to dispatch. This covered outbox messages raised manually and those raised after
                // save changes from event handlers and process managers.

                contextContainsNewOutboxMessages = _context.ChangeTracker
                                           .Entries<OutboxMessage>()
                                           .Any(e => e.State == EntityState.Added);

                //Save the intneded action. This ensures that any database generated values
                //are set on and are available to event handlers.
                await _unitOfWork.SaveChangesAsync();

                if (!contextContainsNewOutboxMessages)
                {
                    contextContainsNewOutboxMessages = _context.ChangeTracker
                                           .Entries<OutboxMessage>()
                                           .Any(e => e.State == EntityState.Added);
                }

                //Save the changes made by any event handlers. We call this on the context
                //directly so that we do not trigger the unit of work pipeline again.
                await _context.SaveChangesAsync();

                transaction.Commit();
            }

            if (contextContainsNewOutboxMessages)
            {
                await _outboxTrigger.TriggerAsync(new OutboxProcessingTriggerInfo());
            }
        }
    }
}
