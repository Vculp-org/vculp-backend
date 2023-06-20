using System;
using System.Threading.Tasks;
using Vculp.Api.Domain.Core.Rbac;
using Vculp.Api.Domain.Interfaces.Common;

namespace Vculp.Api.Domain.Interfaces.Rbac.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<bool> ExistsAsync(string name);
        Task<bool> ExistsWithNameButIdAsync(Guid id, string name);
        void DeleteRole(Role role);
    }
}
