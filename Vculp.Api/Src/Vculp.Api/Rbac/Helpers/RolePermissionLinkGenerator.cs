using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Vculp.Api.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Common.Dtos;
using Vculp.Api.Common.Rbac.Responses;

namespace Vculp.Api.Rbac.Helpers
{
    public class RolePermissionLinkGenerator : IHateoasLinkGenerator<RolePermissionResponse>
    {
        private readonly IUrlHelper _urlHelper;

        public RolePermissionLinkGenerator
        (
            IUrlHelper urlHelper
        )
        {
            _urlHelper = urlHelper ?? throw new ArgumentNullException(nameof(urlHelper));
        }

        public RolePermissionResponse GenerateLinks(RolePermissionResponse dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            dto.Links.Add(new LinkDto(
                _urlHelper.Link(RouteNames.RbacRemoveApplicationPermissionFromRole, new { roleId = dto.RoleId, rolePermissionId = dto.Id }),
                "delete-role-permission",
                HttpMethod.Delete.Method));

            return dto;
        }
    }
}
