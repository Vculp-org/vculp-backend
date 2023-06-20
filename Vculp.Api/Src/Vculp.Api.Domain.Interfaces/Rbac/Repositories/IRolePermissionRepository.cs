using System;
using System.Threading.Tasks;
using Vculp.Api.Domain.Core.Rbac;
using Vculp.Api.Domain.Interfaces.Common;

namespace Vculp.Api.Domain.Interfaces.Rbac.Repositories
{
    public interface IRolePermissionRepository : IRepository<RolePermission>
    {
        Task<bool> RolePermissionExistAsync(Guid roleId, Guid applicationPermissionId);
    }
}
