using System;
using System.Threading.Tasks;
using Vculp.Api.Domain.Core.SharedKernel;

namespace Vculp.Api.Domain.Interfaces.Common
{
    public interface IRepository<T> where T : Entity
    {
        T Find(Guid id);
        Task<T> GetByIdAsync(Guid id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
