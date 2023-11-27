using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Vculp.Api.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Common.Dtos;
using Vculp.Api.Common.FareRecommendation.Commands;
using Vculp.Api.Common.FareRecommendation.Responses;

namespace Vculp.Api.FareRecommendation.Controllers;

[Area("FareRecommendation")]
[Route("fareRecommender-api/fareRecommendation")]
//[Microsoft.AspNetCore.Authorization.Authorize]
public class FareRecommendationController: PagedCollectionController
{
    private readonly IMediator _mediator;
    // private readonly IHateoasLinkGenerator<FareRecommendationResponse> _linkGenerator;

    public FareRecommendationController(IMediator mediator)//, IHateoasLinkGenerator<FareRecommendationResponse> linkGenerator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        // _linkGenerator = linkGenerator ?? throw new ArgumentNullException(nameof(linkGenerator));

    }
    
    
    /// <summary>
    /// Gets all Users.
    /// </summary>
    [SwaggerOperation(Tags = new[] { "FareRecommendation/FareRecommender" })]
    [ProducesResponseType(typeof(LinkedCollectionResourceWrapperDto<FareRecommendationResponse>), 200)]
    [Produces(MediaTypes.FareRecommenderModuleFareRecommendationV1MediaType)]
    [HttpPost(Name = RouteNames.FareRecommenderRecommendFare)]
    public async Task<IActionResult> GetFareRecommendationAsync([FromBody]FareRecommendationCommand command)
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

        if (commandResult.ResultType == CommandResultType.Conflict)
        {
            ModelState.AddModelErrors(commandResult.Errors);
            return Conflict(ModelState);
        }

        //_linkGenerator.GenerateLinks(commandResult.Result);

        return Ok(commandResult.Result);
    }
    
}