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
    [Route("rbac/users")]
    public class UsersController : PagedCollectionController
    {
        private readonly IMediator _mediator;
        private readonly IHateoasLinkGenerator<UserResponse> _linkGenerator;

        public UsersController(
          IMediator mediator,         
          IHateoasLinkGenerator<UserResponse> linkGenerator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));           
            _linkGenerator = linkGenerator ?? throw new ArgumentNullException(nameof(linkGenerator));
        }

        /// <summary>
        /// Gets users
        /// </summary>
        [ProducesResponseType(typeof(LinkedCollectionResourceWrapperDto<UserResponse>), 200)]
        [Produces(MediaTypes.RbacUserV1MediaType)]
        [HttpGet]
        public async Task<IActionResult> GetUser(UsersQuery query)
        {
            var users = await _mediator.Send(query);

            var pagedUsers = users.ToPagedList(users.TotalItems, (int)query.PageNumber, (int)query.PageSize);

            var wrapper = new LinkedCollectionResourceWrapperDto<UserResponse>(pagedUsers);
            wrapper = CreateHateoasLinksForCollection(wrapper, query, pagedUsers.HasNext, pagedUsers.HasPrevious);
            return Ok(wrapper);
        }
    }
}
