using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vculp.Api.Common.Common;
using Vculp.Api.Data.EntityFramework.Extensions;
using Vculp.Api.Domain.Core.SharedKernel;
using Vculp.Api.Domain.Interfaces.Common;
using Vculp.Api.Shared;
using Vculp.Api.Shared.Abstractions.Paging;

namespace Vculp.Api.Data.EntityFramework.Common
{
    public abstract class ReadRepository<T> : IReadRepository<T> where T : Entity
    {
        protected readonly CoreContext Context;
        protected readonly DbSet<T> Set;

        public ReadRepository(CoreContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Set = context.Set<T>();
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await Set.AnyAsync(predicate);
        }

        public virtual async Task<IPagedList<T>> GetAllAsync(PagedResourceParameters resourceParameters)
        {
            var pageNumber = (int)resourceParameters.PageNumber;
            var pageSize = (int)resourceParameters.PageSize;

            var count = await Set.CountAsync();

            var pagedResults = await Set.OrderBy(s => s.Id)
                                        .PageResults(pageNumber, pageSize)
                                        .ToListAsync();

            return pagedResults.ToPagedList(count, pageNumber, pageSize);
        }

        public virtual T Find(Guid id)
        {
            return Set.Find(id);
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await Set.SingleOrDefaultAsync(s => s.Id == id);
        }
    }
}
