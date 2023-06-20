using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vculp.Api.Domain.Core.Rbac;
using Vculp.Api.Domain.Interfaces.Rbac.Caching;
using Vculp.Api.Domain.Interfaces.Rbac.Repositories;

namespace Vculp.Api.Data.EntityFramework.Rbac.Repositories
{
    public class CachingApplicationPermissionRepository : IApplicationPermissionRepository
    {
        private readonly IApplicationPermissionRepository _applicationPermissionRepository;
        private readonly IApplicationPermissionCache _applicationPermissionCache;

        public CachingApplicationPermissionRepository
        (
            IApplicationPermissionRepository applicationPermissionRepository,
            IApplicationPermissionCache applicationPermissionCache)
        {
            _applicationPermissionRepository = applicationPermissionRepository ??
                                               throw new ArgumentNullException(nameof(applicationPermissionRepository));
            _applicationPermissionCache = applicationPermissionCache ??
                                          throw new ArgumentNullException(nameof(applicationPermissionCache));
        }

        public ApplicationPermission Find(Guid id)
        {
            return _applicationPermissionRepository.Find(id);
        }

        public async Task<ApplicationPermission> GetByIdAsync(Guid id)
        {
            return await _applicationPermissionRepository.GetByIdAsync(id);
        }

        public void Add(ApplicationPermission entity)
        {
            _applicationPermissionRepository.Add(entity);
        }

        public void Update(ApplicationPermission entity)
        {
            _applicationPermissionRepository.Update(entity);
        }

        public void Delete(ApplicationPermission entity)
        {
            _applicationPermissionRepository.Delete(entity);
        }

        public async Task<IEnumerable<ApplicationPermission>> GetForExternalUserId(int externalUserId)
        {
            var cachedApplicationPermissions =
                _applicationPermissionCache.GetPermissionsForExternalUserId(externalUserId);
            if (cachedApplicationPermissions != null && cachedApplicationPermissions.Any())
            {
                return cachedApplicationPermissions;
            }

            var applicationPermissions = await _applicationPermissionRepository.GetForExternalUserId(externalUserId);
            _applicationPermissionCache.AddExternalUserPermissions(externalUserId, applicationPermissions);
            return applicationPermissions;
        }
    }
}