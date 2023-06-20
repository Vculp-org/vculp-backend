using System;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Rbac.Responses;
using Vculp.Api.Domain.Core.Rbac;

namespace Vculp.Api.Common.Rbac.Mappers
{
    public class RolePermissionMapper : Mapper<RolePermission>
    {
        static RolePermissionMapper()
        {   
        }

        new public static TDestination MapTo<TDestination>(RolePermission source)
          => Mapper<RolePermission>.MapTo<TDestination>(source);

        public static RolePermissionResponse MapToRolePermissionResponse(RolePermission source, ApplicationPermission applicationPermission)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (applicationPermission == null)
            {
                throw new ArgumentNullException(nameof(applicationPermission));
            }

            return new RolePermissionResponse
            {
                Id = source.Id,
                RoleId = source.RoleId,
                ApplicationPermissionId = source.ApplicationPermissionId,
                PermissionKey = applicationPermission.PermissionKey,
                DisplayName = applicationPermission.DisplayName,
                Name = applicationPermission.DisplayName,
                Description = applicationPermission.Description
            };
        }
    }
}
