using System.Collections.Generic;
using System.Threading.Tasks;
using Vculp.Api.Domain.Core.Rbac;
using Vculp.Api.Domain.Interfaces.Common;

namespace Vculp.Api.Domain.Interfaces.Rbac.Repositories
{
    public interface IApplicationPermissionRepository : IRepository<ApplicationPermission>
    {
        Task<IEnumerable<ApplicationPermission>> GetForExternalUserId(int externalUserId);
    }
}
