using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using Vculp.Api.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Common.Dtos;
using Microsoft.AspNetCore.Mvc;
using Vculp.Api.Common.Location.Commands;
using Vculp.Api.Common.Location.Queries;
using Vculp.Api.Common.Location.Responses;


namespace Vculp.Api.User.Controllers
{
    [Area("Location")]
    [Route("location-api/location")]
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class LocationControllers : PagedCollectionController
    {
        private readonly IMediator _mediator;

        // public LocationControllers(IMediator mediator, IHateoasLinkGenerator<LocationResponse> linkGenerator)
        public LocationControllers(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        
        /// <summary>
        /// Push updated User Location
        /// </summary>
        /// <response code="201">Location updated</response>
        /// <response code="400">When a model with invalid structure is supplied</response>
        /// <response code="422">When the model structure is correct but validation fails</response>
        [SwaggerOperation(Tags = new[] { "Location/Locations" })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
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
        
        
        /// <summary>
        /// Gets nearest vehicles.
        /// </summary>
        [SwaggerOperation(Tags = new[] { "Location/Locations" })]
        [ProducesResponseType(typeof(LinkedCollectionResourceWrapperDto<NearestDriverResponse>), 200)]
        [Produces(MediaTypes.LocationModuleLocationV1MediaType)]
        [HttpGet(Name = RouteNames.LocationGetNearestDrivers)]
        public async Task<IActionResult> GetNearestDrivers(NearestQuery query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
        
            var nearestDrivers = await _mediator.Send(query);

            return Ok(nearestDrivers);
        }
        
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