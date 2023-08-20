using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using Vculp.Api.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Common.Dtos;
using Vculp.Api.Common.User.Responses;
using Microsoft.AspNetCore.Mvc;
using Vculp.Api.Common.Booking.Commands;
using Vculp.Api.Common.Location.Commands;
using Vculp.Api.Common.Location.Queries;
using Vculp.Api.Common.Location.Responses;


namespace Vculp.Api.Booking.Controllers
{
    [Area("Booking")]
    [Route("booking-api/booking")]
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class BookingControllers : PagedCollectionController
    {
        private readonly IMediator _mediator;

        // public LocationControllers(IMediator mediator, IHateoasLinkGenerator<LocationResponse> linkGenerator)
        public BookingControllers(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        
        /// <summary>
        /// This method will be initiated when user is starting booking and bidding process
        /// This method will do the following
        /// "Input: {from},{to},fare-details,vehicle-type
        /// Response: RideId, Expiration, list of drivers
        ///     Save details
        ///     GetNearestDrivers
        /// Save Booking Id and drivers to Cache (will be used in polling)
        /// SendReponse To User
        ///     Async while (ride accepted/bidding started or limit reached)
        /// NotifiyUser-driver-sync"
        /// </summary>
        /// <response code="201">RideId, Expiration, list of drivers</response>
        /// <response code="400">When a model with invalid structure is supplied</response>
        /// <response code="422">When the model structure is correct but validation fails</response>
        [SwaggerOperation(Tags = new[] { "Booking/Bookings" })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Consumes(MediaTypes.BookingModuleRequestRideV1MediaType)]
        [Produces(MediaTypes.BookingModuleBookingV1MediaType)]
        [HttpPost(Name = RouteNames.BookingRequestRide)]
        public async Task<IActionResult> RequestRide([FromBody] RequestRideCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }
        
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
        
            // var commandResult = await _mediator.Send(command);
            //
            // if (commandResult.ResultType == CommandResultType.UnprocessableEntity)
            // {
            //     ModelState.AddModelErrors(commandResult.Errors);
            //     return UnprocessableEntity(ModelState);
            // }
            
            return NoContent();
        }

        
        // /// <summary>
        // /// Gets nearest vehicles.
        // /// </summary>
        // [SwaggerOperation(Tags = new[] { "Location/Locations" })]
        // [ProducesResponseType(typeof(LinkedCollectionResourceWrapperDto<NearestDriverResponse>), 200)]
        // [Produces(MediaTypes.LocationModuleLocationV1MediaType)]
        // [HttpGet(Name = RouteNames.LocationGetNearestDrivers)]
        // public async Task<IActionResult> GetNearestDrivers(NearestQuery query)
        // {
        //     if (!ModelState.IsValid)
        //         return BadRequest(ModelState);
        //
        //     var nearestDrivers = await _mediator.Send(query);
        //
        //     return Ok(nearestDrivers);
        // }
    }
}