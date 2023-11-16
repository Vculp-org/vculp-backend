using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using Vculp.Api.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Common.Dtos;
using Vculp.Api.Common.FavoriteRegion.Responses;
using Vculp.Api.Common.User.Responses;

namespace Vculp.Api.FavoriteRegion.Helpers
{
    public class FavoriteRegionLinkGenerator : IHateoasLinkGenerator<FavoriteRegionResponse>
    {
        private readonly IUrlHelper _urlHelper;
        public FavoriteRegionLinkGenerator(IUrlHelper urlHelper
    )
        {
            _urlHelper = urlHelper ?? throw new ArgumentNullException(nameof(urlHelper));
        }

        public FavoriteRegionResponse GenerateLinks(FavoriteRegionResponse dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            dto.Links.Add(new LinkDto(
                _urlHelper.Link(RouteNames.FavoriteRegionById, new { FavoriteRegionId = dto.FavoriteRegionId }),
                LinkRels.Self,
                HttpMethod.Get.Method));

            return dto;
        }
    }
}
