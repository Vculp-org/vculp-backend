using System.Linq;
using System.Threading.Tasks;
using CorrelationId.Abstractions;
using Microsoft.EntityFrameworkCore;
using Vculp.Api.Domain.Core.SharedKernel.Interfaces;
using Vculp.Api.Domain.Interfaces.Common;

namespace Vculp.Api.Data.EntityFramework.Common.UnitOfWork
{
    public class CorrelatableEntityPopulatingUnitOfWork : IUnitOfWork
    {
        private readonly CoreContext _context;
        private readonly ICorrelationContextAccessor _correlationContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public CorrelatableEntityPopulatingUnitOfWork(
            CoreContext context,
            ICorrelationContextAccessor correlationContextAccessor,
            IUnitOfWork unitOfWork)
        {
            _context = context;
            _correlationContextAccessor = correlationContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public async Task SaveChangesAsync()
        {
            var correlationId = _correlationContextAccessor?.CorrelationContext?.CorrelationId;

            if (!string.IsNullOrWhiteSpace(correlationId))
            {
                var createdCorrelatableEntities = _context.ChangeTracker
                                                          .Entries<ICorrelatable>()
                                                          .Where(e => e.State == EntityState.Added)
                                                          .Select(e => e.Entity);

                foreach (var entity in createdCorrelatableEntities)
                {
                    _context.Entry(entity).Property(e => e.CorrelationId).CurrentValue = correlationId;
                }
            }

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
