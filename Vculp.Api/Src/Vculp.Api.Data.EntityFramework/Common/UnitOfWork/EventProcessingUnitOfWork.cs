using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vculp.Api.Domain.Core.SharedKernel;
using Vculp.Api.Domain.Core.SharedKernel.EventReduction;
using Vculp.Api.Domain.Interfaces.Common;
using Vculp.DDD.Shared.Interfaces;

namespace Vculp.Api.Data.EntityFramework.Common.UnitOfWork
{
    public class EventProcessingUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly ITransactionalDomainEventDispatcher _eventDispatcher;
        private readonly IDomainEventReducer _eventReducer;
        private readonly IUnitOfWork _unitOfWork;

        public EventProcessingUnitOfWork(
            DbContext context,
            ITransactionalDomainEventDispatcher eventDispatcher,
            IDomainEventReducer eventReducer,
            IUnitOfWork unitOfWork)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _eventDispatcher = eventDispatcher ?? throw new ArgumentNullException(nameof(eventDispatcher));
            _eventReducer = eventReducer ?? throw new ArgumentNullException(nameof(eventReducer));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task SaveChangesAsync()
        {
            // We call Save Changes here, before dispatching events. This ensures that any database generated values
            //are set on and are available to event handlers.

            // TODO: Move away from using database generted values for properties required in domain events. We can then
            // dispatch before save changes, rather than after.
            await _unitOfWork.SaveChangesAsync();

            var aggregates = _context.ChangeTracker.Entries<AggregateRoot>().Select(a => a.Entity).ToList();
            var domainEvents = aggregates.SelectMany(a => _eventReducer.ReduceEvents(a));

            if (domainEvents.Any())
            {
                await _eventDispatcher.DispatchAsync(domainEvents);
            }

            foreach (var aggregate in aggregates)
            {
                aggregate.ClearEvents();
            }
        }
    }
}
