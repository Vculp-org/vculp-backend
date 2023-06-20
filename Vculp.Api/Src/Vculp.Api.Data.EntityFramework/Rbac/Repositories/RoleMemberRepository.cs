using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vculp.Api.Data.EntityFramework.Common;
using Vculp.Api.Domain.Core.Rbac;
using Vculp.Api.Domain.Interfaces.Rbac.Repositories;

namespace Vculp.Api.Data.EntityFramework.Rbac.Repositories
{
    public class RoleMemberRepository : Repository<RoleMember>, IRoleMemberRepository
    {
        public RoleMemberRepository(CoreContext context)
           : base(context)
        {
        }

        public async Task<bool> IsMemberAsync(Guid roleId, Guid userId)
        {
            return await Context.RoleMembers.AnyAsync(r => r.RoleId == roleId && r.UserId == userId);
        }

        protected override IQueryable<RoleMember> IncludeAll()
        {
            return DbSet;
        }
    }
}
