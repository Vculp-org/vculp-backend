using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Vculp.Api.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Common.Dtos;
using Vculp.Api.Common.Rbac.Responses;

namespace Vculp.Api.Rbac.Helpers
{
    public class RoleMemberLinkGenerator : IHateoasLinkGenerator<RoleMemberResponse>
    {
        private readonly IUrlHelper _urlHelper;

        public RoleMemberLinkGenerator
        (
            IUrlHelper urlHelper
        )
        {
            _urlHelper = urlHelper ?? throw new ArgumentNullException(nameof(urlHelper));
        }

        public RoleMemberResponse GenerateLinks(RoleMemberResponse dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            dto.Links.Add(new LinkDto(
                _urlHelper.Link(RouteNames.RbacRemoveUserFromRole, new { roleId = dto.RoleId, roleMemberId = dto.Id }),
                "delete-role-member",
                HttpMethod.Delete.Method));

            return dto;
        }
    }
}
