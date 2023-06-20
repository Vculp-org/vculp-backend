using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Vculp.Api.Domain.Core.Rbac;
using Vculp.Api.Domain.Interfaces.Rbac.Caching;

namespace Vculp.Api.Data.EntityFramework.Rbac.Caching
{
    public class ApplicationPermissionCache : IApplicationPermissionCache
    {
        private readonly ConcurrentDictionary<int, IEnumerable<ApplicationPermission>> _applicationPermissions;

        public ApplicationPermissionCache()
        {
            _applicationPermissions = new ConcurrentDictionary<int, IEnumerable<ApplicationPermission>>();
        }
        public void Clear()
        {
            _applicationPermissions.Clear();
        }

        public void AddExternalUserPermissions(int externalUserId, IEnumerable<ApplicationPermission> userPermissions)
        {
            if (externalUserId < 1)
            {
                throw new ArgumentException(@"User Id should be greater than zero.", nameof(externalUserId));
            }

            if (userPermissions == null)
            {
                throw new ArgumentNullException(nameof(userPermissions));
            }

            _applicationPermissions.AddOrUpdate(externalUserId, userPermissions, (k, v) => userPermissions);
        }

        public IEnumerable<ApplicationPermission> GetPermissionsForExternalUserId(int externalUserId)
        {
            if (externalUserId < 1)
            {
                throw new ArgumentException(@"User Id should be greater than zero.", nameof(externalUserId));
            }

            return _applicationPermissions.TryGetValue(externalUserId, out var permissions) ? permissions : null;
        }
    }
}