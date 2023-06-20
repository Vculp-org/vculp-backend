using System;
using Microsoft.AspNetCore.Mvc;
using Vculp.Api.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Common.Dtos;
using Vculp.Api.Common.Rbac.Commands;
using Vculp.Api.Common.Rbac.Responses;

namespace Vculp.Api.Rbac.Helpers
{
    public class RoleLinkGenerator : IHateoasLinkGenerator<RoleResponse>
    {
        private readonly IUrlHelper _urlHelper;

        public RoleLinkGenerator(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper ?? throw new ArgumentNullException(nameof(urlHelper));
        }

        public RoleResponse GenerateLinks(RoleResponse dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            dto.Links.Add(new LinkDto(
                    _urlHelper.Link(RouteNames.RbacUpdateRole, new UpdateRoleCommand { RoleId = dto.RoleId }),
                    "update-role",
                    ApiMethodContants.HttpPut));

            dto.Links.Add(new LinkDto(
                    _urlHelper.Link(RouteNames.RbacGetRoleMembers, new { RoleId = dto.RoleId }),
                    "role-members",
                    ApiMethodContants.HttpGet));

            dto.Links.Add(new LinkDto(
                    _urlHelper.Link(RouteNames.RbacGetRolePermissions, new { RoleId = dto.RoleId }),
                    "role-permissions",
                    ApiMethodContants.HttpGet));
            
            dto.Links.Add(new LinkDto(
                    _urlHelper.Link(RouteNames.RbacRemoveRole, new { RoleId = dto.RoleId }),
                    "delete-role",
                    ApiMethodContants.HttpDelete));

            return dto;
        }
    }
}
