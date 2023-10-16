using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Vculp.Api.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Location.Commands;

namespace Vculp.Api.Location.Controllers;

[Area("Location")]
[Route("fav-location-api/fav-location")]
[Microsoft.AspNetCore.Authorization.Authorize]
public class FavoriteLocationController : PagedCollectionController
{
    private readonly IMediator _mediator;
    public FavoriteLocationController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    
    /// <summary>
    /// Push updated User Location
    /// </summary>
    /// <response code="201">Location updated</response>
    /// <response code="400">When a model with invalid structure is supplied</response>
    /// <response code="422">When the model structure is correct but validation fails</response>
    [SwaggerOperation(Tags = new[] { "Location/FavoriteLocations" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [Consumes(MediaTypes.LocationModuleAddFavLocationV1MediaType)]
    [Produces(MediaTypes.LocationModuleFavLocationV1MediaType)]
    [HttpPost(Name = RouteNames.LocationAddFavoriteLocation)]
    public async Task<IActionResult> AddFavoriteLocation([FromBody] AddFavoriteLocationCommand command)
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
}