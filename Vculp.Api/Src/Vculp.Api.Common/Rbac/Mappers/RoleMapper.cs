using Vculp.Api.Common.Common;
using Vculp.Api.Common.Rbac.Responses;
using Vculp.Api.Domain.Core.Rbac;

namespace Vculp.Api.Common.Rbac.Mappers
{
    public class RoleMapper : Mapper<Role>
    {
        static RoleMapper()
        {
            CreateMapTo<RoleResponse>(MapToRoleResponse);

        }

        new public static TDestination MapTo<TDestination>(Role source)
          => Mapper<Role>.MapTo<TDestination>(source);

        public static RoleResponse MapToRoleResponse(Role role)
        {
            return new RoleResponse
            {
                RoleId = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }
    }
}
