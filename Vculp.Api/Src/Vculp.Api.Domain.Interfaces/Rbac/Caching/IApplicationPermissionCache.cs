using System.Collections.Generic;
using Vculp.Api.Domain.Core.Rbac;

namespace Vculp.Api.Domain.Interfaces.Rbac.Caching
{
    public interface IApplicationPermissionCache
    {
        void Clear();
        void AddExternalUserPermissions(int externalUserId, IEnumerable<ApplicationPermission> userPermissions);
        IEnumerable<ApplicationPermission> GetPermissionsForExternalUserId(int externalUserId);
    }
}