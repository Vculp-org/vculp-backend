using System;
using System.Threading.Tasks;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;
using Vculp.Api.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Common.Dtos;
using Vculp.Api.Common.User.Queries;
using Vculp.Api.Common.User.Responses;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Vculp.Api.Common.Location.Commands;
using Vculp.Api.Common.User.Commands;
using Vculp.Api.Common.Vehicle.Queries;
using Vculp.Api.Common.Vehicle.Responses;


namespace Vculp.Api.User.Controllers
{
    [Area("Location")]
    [Route("location-api/location")]
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class LocationControllers : PagedCollectionController
    {
        private readonly IMediator _mediator;
        private readonly IHateoasLinkGenerator<LocationResponse> _linkGenerator;

        // public LocationControllers(IMediator mediator, IHateoasLinkGenerator<LocationResponse> linkGenerator)
        public LocationControllers(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            // _linkGenerator = linkGenerator ?? throw new ArgumentNullException(nameof(linkGenerator));
        }
        
        /// <summary>
        /// Push updated User Location
        /// </summary>
        /// <response code="201">Location updated</response>
        /// <response code="400">When a model with invalid structure is supplied</response>
        /// <response code="422">When the model structure is correct but validation fails</response>
        [SwaggerOperation(Tags = new[] { "Location/Locations" })]
        [ProducesResponseType(typeof(LocationResponse), 201)]
        [Consumes(MediaTypes.LocationModulePushLocationV1MediaType)]
        [Produces(MediaTypes.LocationModuleLocationV1MediaType)]
        [HttpPost(Name = RouteNames.LocationPushLocation)]
        public async Task<IActionResult> PushLocation([FromBody] PushLocationCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }
        
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
        
            var commandResult = await _mediator.Send(command);
            
            if (commandResult.ResultType == CommandResultType.UnprocessableEntity)
            {
                ModelState.AddModelErrors(commandResult.Errors);
                return UnprocessableEntity(ModelState);
            }
            
            return NoContent();
        }
        
        
        // /// <summary>
        // /// Gets nearest vehicles.
        // /// </summary>
        // [SwaggerOperation(Tags = new[] { "Location/Locations" })]
        // [ProducesResponseType(typeof(LinkedCollectionResourceWrapperDto<VehicleResponse>), 200)]
        // [Produces(MediaTypes.LocationModuleLocationV1MediaType)]
        // [HttpGet(Name = RouteNames.LocationGetNearestDrivers)]
        // public async Task<IActionResult> GetNearestDrivers(NearestQuery query)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest();
        //     }
        //
        //     var userResponses = await _mediator.Send(query);
        //
        //     foreach (var userResponse in userResponses)
        //     {
        //         _linkGenerator.GenerateLinks(userResponse);
        //     }
        //
        //     GeneratePagingHeaders(new PagingMetadata
        //     {
        //         TotalItems = userResponses.TotalItems,
        //         TotalPages = userResponses.TotalPages,
        //         CurrentPage = userResponses.CurrentPage,
        //         PageSize = userResponses.PageSize
        //     });
        //
        //     var wrapper = new LinkedCollectionResourceWrapperDto<UserResponse>(userResponses);
        //
        //     wrapper = CreateHateoasLinksForCollection(wrapper, query, userResponses.HasNext, userResponses.HasPrevious);
        //
        //     wrapper.Links.Add(
        //         new LinkDto(
        //             Url.Link(RouteNames.UserCreateUser, new { }),
        //             "create-contract",
        //             HttpMethod.Post.Method));
        //
        //     return Ok(wrapper);
        // }
        
        // /// <summary>
        // /// Get User by Id.
        // /// </summary>
        // [SwaggerOperation(Tags = new[] { "User/Users" })]
        // [ProducesResponseType(typeof(LinkedCollectionResourceWrapperDto<UserResponse>), 200)]
        // [Produces(MediaTypes.UserModuleUserV1MediaType)]
        // [HttpGet("{userId}", Name = RouteNames.UserGetUserById)]
        // public async Task<IActionResult> GetUserByIdAsync(UserQuery query)
        // {
        //     var userResponse = await _mediator.Send(query);
        //
        //     if (userResponse == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     _linkGenerator.GenerateLinks(userResponse);
        //
        //     return Ok(userResponse);
        // }

    }
}