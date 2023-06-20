using Vculp.Api.Common.Common;
using Vculp.Api.Common.Rbac.Responses;
using Vculp.Api.Domain.Core.Rbac;

namespace Vculp.Api.Common.Rbac.Mappers
{
    public class ApplicationPermissionMapper : Mapper<ApplicationPermission>
    {
        static ApplicationPermissionMapper()
        {
            CreateMapTo<ApplicationPermissionResponse>(MapToApplicationPermissionReponse);

        }

        new public static TDestination MapTo<TDestination>(ApplicationPermission source)
           => Mapper<ApplicationPermission>.MapTo<TDestination>(source);

        private static ApplicationPermissionResponse MapToApplicationPermissionReponse(ApplicationPermission permission)
        {
            return new ApplicationPermissionResponse
            {
                ApplicationPermissionId = permission.Id,
                PermissionKey = permission.PermissionKey,
                DisplayName = permission.DisplayName,
                Description = permission.Description
            };
        }
    }
}
