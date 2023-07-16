using System;
using Microsoft.AspNetCore.Mvc;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Notifications.Responses;

namespace Vculp.Api.Notifications.Helpers
{
    public class ContactLinkGenerator : IHateoasLinkGenerator<ContactResponse>
    {
        private readonly IUrlHelper _urlHelper;

        public ContactLinkGenerator
        (
            IUrlHelper urlHelper
        )
        {
            _urlHelper = urlHelper ?? throw new ArgumentNullException(nameof(urlHelper));
        }

        public ContactResponse GenerateLinks(ContactResponse dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            // dto.Links.Add(new LinkDto(
            //     _urlHelper.Link(RouteNames.NotificationsGetContacts, new { }),
            //     LinkRels.Self,
            //     HttpMethod.Get.Method));

            return dto;
        }
    }
}
