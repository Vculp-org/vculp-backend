using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Vculp.Api.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Common.Dtos;
using Vculp.Api.Common.Notifications.Queries;
using Vculp.Api.Common.Notifications.Responses;

namespace Vculp.Api.Notifications.Controllers
{
    [Area("Notifications")]
    [Route("notifications-api/contacts")]
    [Authorize]
    public class NotificationsContactController : PagedCollectionController
    {
        private readonly IMediator _mediator;
        private readonly IHateoasLinkGenerator<ContactResponse> _linkGenerator;
        
        public NotificationsContactController
        (
          IMediator mediator,
        IHateoasLinkGenerator<ContactResponse> linkGenerator
        )
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _linkGenerator = linkGenerator ?? throw new ArgumentNullException(nameof(linkGenerator));

        }

        /// <summary>
        /// Gets all contacts for the notifications module.
        /// </summary>
        // [SwaggerOperation(Tags = new[] { "Notification/Contact" })]
        // [ProducesResponseType(typeof(LinkedCollectionResourceWrapperDto<ContactResponse>), 200)]
        // [Produces(MediaTypes.NotificationsModuleContactsV1MediaType)]
        // [HttpGet(Name = RouteNames.NotificationsGetContacts)]
        // public async Task<IActionResult> GetAllContactsAsync(NotificationContactsQuery query)
        // {
        //     var notificationContacts = await _mediator.Send(query);
        //
        //     foreach (var contact in notificationContacts)
        //     {
        //         _linkGenerator.GenerateLinks(contact);
        //     }
        //
        //     GeneratePagingHeaders(new PagingMetadata
        //     {
        //         TotalItems = notificationContacts.TotalItems,
        //         TotalPages = notificationContacts.TotalPages,
        //         CurrentPage = notificationContacts.CurrentPage,
        //         PageSize = notificationContacts.PageSize
        //     });
        //
        //     var wrapper = new LinkedCollectionResourceWrapperDto<ContactResponse>(notificationContacts);
        //     wrapper = CreateHateoasLinksForCollection(wrapper, query, notificationContacts.HasNext, notificationContacts.HasPrevious);
        //
        //     wrapper.Links.Add(new LinkDto(
        //         Url.Link(RouteNames.NotificationsGetContacts, new { }),
        //         "contacts",
        //         "GET"));
        //
        //     return Ok(wrapper);
        // }

    }
}
