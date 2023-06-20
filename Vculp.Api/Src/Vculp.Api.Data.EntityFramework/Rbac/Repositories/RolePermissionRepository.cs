using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vculp.Api.Data.EntityFramework.Common;
using Vculp.Api.Domain.Core.Rbac;
using Vculp.Api.Domain.Interfaces.Rbac.Repositories;

namespace Vculp.Api.Data.EntityFramework.Rbac.Repositories
{
    public class RolePermissionRepository : Repository<RolePermission>, IRolePermissionRepository
    {
        public RolePermissionRepository(CoreContext context)
            : base(context)
        {
        }

        public async Task<bool> RolePermissionExistAsync(Guid roleId, Guid applicationPermissionId)
        {
            return await IncludeAll().AnyAsync(x => x.RoleId == roleId && x.ApplicationPermissionId == applicationPermissionId);
        }

        protected override IQueryable<RolePermission> IncludeAll()
        {
            return DbSet;
        }
    }
}
