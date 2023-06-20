using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vculp.Api.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Common.Dtos;
using Vculp.Api.Common.Rbac.Queries;
using Vculp.Api.Common.Rbac.Responses;
using Vculp.Api.Shared;

namespace Vculp.Api.Rbac.Controllers
{
    [Authorize]
    [Route("rbac/application-permissions")]
    public class ApplicationPermissionsController : PagedCollectionController
    {
        private readonly IMediator _mediator;
        private readonly ICurrentUserAccessor _currentUserAccessor;
        private readonly IHateoasLinkGenerator<ApplicationPermissionResponse> _linkGenerator;

        public ApplicationPermissionsController(
            IMediator mediator,
            ICurrentUserAccessor currentUserAccessor,
            IHateoasLinkGenerator<ApplicationPermissionResponse> linkGenerator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _currentUserAccessor = currentUserAccessor ?? throw new ArgumentNullException(nameof(currentUserAccessor));
            _linkGenerator = linkGenerator ?? throw new ArgumentNullException(nameof(linkGenerator));
        }

        /// <summary>
        /// Gets the application permissions assigned to the authenticated user
        /// </summary>
        [Route("/rbac/me/application-permissions", Name = RouteNames.RbacGetAuthenticatedUserApplicationPermissions)]
        [ProducesResponseType(typeof(LinkedCollectionResourceWrapperDto<ApplicationPermissionResponse>), 200)]
        [Produces(MediaTypes.RbacApplicationPermissionV1MediaType)]
        [HttpGet]
        public async Task<IActionResult> GetApplicationPermissionsForAuthenticatedUser(AuthenticatedUserApplicationPermissionsQuery query)
        {           

            var currentUserId = _currentUserAccessor.UserId;

            if (!currentUserId.HasValue)
            {
                return NotFound();
            }
           
            var applicationPermissions = await _mediator.Send(query);

            var pagedPermissions = applicationPermissions.ToPagedList(applicationPermissions.TotalItems, (int)query.PageNumber, (int)query.PageSize);

            var wrapper = new LinkedCollectionResourceWrapperDto<ApplicationPermissionResponse>(pagedPermissions);
            wrapper = CreateHateoasLinksForCollection(wrapper, query, pagedPermissions.HasNext, pagedPermissions.HasPrevious);
            return Ok(wrapper);
        }


        /// <summary>
        /// Gets application permissions
        /// </summary>
        [ProducesResponseType(typeof(LinkedCollectionResourceWrapperDto<ApplicationPermissionResponse>), 200)]
        [Produces(MediaTypes.RbacApplicationPermissionV1MediaType)]
        [HttpGet]
        public async Task<IActionResult> GetApplicationPermissions(ApplicationPermissionsQuery query)
        {
            var applicationPermissions = await _mediator.Send(query);            

            var pagedPermissions = applicationPermissions.ToPagedList(applicationPermissions.TotalItems, (int)query.PageNumber, (int)query.PageSize);

            var wrapper = new LinkedCollectionResourceWrapperDto<ApplicationPermissionResponse>(pagedPermissions);
            wrapper = CreateHateoasLinksForCollection(wrapper, query, pagedPermissions.HasNext, pagedPermissions.HasPrevious);
            return Ok(wrapper);
        }
    }
}
