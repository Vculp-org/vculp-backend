using System;
using System.Threading.Tasks;
using Vculp.Api.Domain.Core.Rbac;
using Vculp.Api.Domain.Interfaces.Common;

namespace Vculp.Api.Domain.Interfaces.Rbac.Repositories
{
    public interface IRoleMemberRepository : IRepository<RoleMember>
    {
        Task<bool> IsMemberAsync(Guid roleId, Guid userId);
    }
}
