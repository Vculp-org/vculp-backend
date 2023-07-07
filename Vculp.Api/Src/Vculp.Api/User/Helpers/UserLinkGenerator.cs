using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Vculp.Api.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Common.Dtos;
using Vculp.Api.Common.User.Responses;

namespace Vculp.Api.User.Helpers;

public class UserLinkGenerator : IHateoasLinkGenerator<UserResponse>
{
    private readonly IUrlHelper _urlHelper;

    public UserLinkGenerator
    (
        IUrlHelper urlHelper
    )
    {
        _urlHelper = urlHelper ?? throw new ArgumentNullException(nameof(urlHelper));
    }

    public UserResponse GenerateLinks(UserResponse dto)
    {
        if (dto == null)
        {
            throw new ArgumentNullException(nameof(dto));
        }

        dto.Links.Add(new LinkDto(
            _urlHelper.Link(RouteNames.UserGetUserById, new { UserId = dto.UserId }),
            LinkRels.Self,
            HttpMethod.Get.Method));

        return dto;
    }
}