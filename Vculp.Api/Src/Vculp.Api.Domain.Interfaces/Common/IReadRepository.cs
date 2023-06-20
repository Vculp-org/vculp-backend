using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Vculp.Api.Common.Common;
using Vculp.Api.Domain.Core.SharedKernel;
using Vculp.Api.Shared.Abstractions.Paging;

namespace Vculp.Api.Domain.Interfaces.Common
{
    public interface IReadRepository<T> where T : Entity
    {
        Task<IPagedList<T>> GetAllAsync(PagedResourceParameters resourceParameters);

        Task<T> GetByIdAsync(Guid id);

        T Find(Guid id);

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    }
}
