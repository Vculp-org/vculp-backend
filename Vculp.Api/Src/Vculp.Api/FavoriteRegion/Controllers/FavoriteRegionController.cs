using Castle.Core.Configuration;
using MediatR;
using Microsoft.AspNet.SignalR.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;
using Vculp.Api.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Common.Dtos;
using Vculp.Api.Common.FavoriteRegion.Commands;
using Vculp.Api.Common.FavoriteRegion.Queries;
using Vculp.Api.Common.FavoriteRegion.Responses;
using Vculp.Api.Common.User.Commands;
using Vculp.Api.Common.User.Queries;
using Vculp.Api.Common.User.Responses;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Vculp.Api.FavoriteRegion.Controllers
{
    [Area("Favoriteregion")]
    [Route("favoriteregion-api/favoriteregion")]
    //[Microsoft.AspNetCore.Authorization.Authorize]
    public class FavoriteRegionController : PagedCollectionController
    {
        private readonly IMediator _mediator;
        private readonly IHateoasLinkGenerator<FavoriteRegionResponse> _linkGenerator;
        private readonly IConfiguration _configuration;

        public FavoriteRegionController(IMediator mediator, IHateoasLinkGenerator<FavoriteRegionResponse> linkGenerator,
            IConfiguration configuration)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _linkGenerator = linkGenerator ?? throw new ArgumentNullException(nameof(linkGenerator));
            _configuration = configuration;
        }

        /// <summary>
        /// Create Favorite Region
        /// </summary>
        /// <response code="201">Returns created Favorite Region</response>
        /// <response code="400">When a model with invalid structure is supplied</response>
        /// <response code="409">When the Favorite Region is already in use</response>
        /// <response code="422">When the model structure is correct but validation fails</response>
        [SwaggerOperation(Tags = new[] { "FavoriteRegion/FavoriteRegion" })]
        [ProducesResponseType(typeof(FavoriteRegionResponse), 201)]
        [Consumes(MediaTypes.FavoriteRegionModuleCreateMediaType)]
        [Produces(MediaTypes.FavoriteRegionModuleMediaType)]
        [HttpPost(Name = RouteNames.FavoriteRegion)]
        public async Task<IActionResult> CreateFavoriteRegionAsync([FromBody] CreateFavoriteRegionCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            command.Radius = _configuration.GetValue<double>("Radius");
            
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

            _linkGenerator.GenerateLinks(commandResult.Result);

            return CreatedAtRoute(
                RouteNames.FavoriteRegionById,
                new FavoriteRegionQuery() { FavoriteRegionId = commandResult.Result.FavoriteRegionId },
                commandResult.Result);
        }


        /// <summary>
        /// Get Favorite Regions by Id.
        /// </summary>
        [SwaggerOperation(Tags = new[] { "FavoriteRegion/FavoriteRegion" })]
        [ProducesResponseType(typeof(LinkedCollectionResourceWrapperDto<FavoriteRegionResponse>), 200)]
        [Produces(MediaTypes.FavoriteRegionModuleMediaType)]
        [HttpGet("{favoriteRegionId}", Name = RouteNames.FavoriteRegionById)]
        public async Task<IActionResult> GetFavoriteRegionByIdAsync(FavoriteRegionQuery query)
        {
            var favoriteRegions = await _mediator.Send(query);

            if (favoriteRegions == null)
            {
                return NotFound();
            }

            _linkGenerator.GenerateLinks(favoriteRegions);

            return Ok(favoriteRegions);
        }

        /// <summary>
        /// Get Favorite Regions by User.
        /// </summary>
        [SwaggerOperation(Tags = new[] { "FavoriteRegion/FavoriteRegion" })]
        [ProducesResponseType(typeof(LinkedCollectionResourceWrapperDto<FavoriteRegionResponse>), 200)]
        [Produces(MediaTypes.FavoriteRegionModuleMediaType)]
        [HttpGet(Name = RouteNames.FavoriteRegions)]
        public async Task<IActionResult> GetFavoriteRegionsByUserIdAsync(FavoriteRegionsQuery query)
        {
            var favoriteRegions = await _mediator.Send(query);

            if (favoriteRegions == null)
            {
                return NotFound();
            }

            foreach (var item in favoriteRegions)
            {
                _linkGenerator.GenerateLinks(item);
            }
           

            return Ok(favoriteRegions);
        }

        /// <summary>
        /// Updates favorite region for the favorite region module
        /// </summary>
        /// <response code="200">Returns the updated favorite region</response>
        /// <response code="404">When the favorite region does not exist</response>
        /// <response code="409">When the favorite region name already exist/invalid favorite region type</response>
        /// <response code="422">When the model structure is correct but validation fails</response>
        [SwaggerOperation(Tags = new[] { "FavoriteRegion/FavoriteRegion" })]
        [ProducesResponseType(typeof(FavoriteRegionResponse), 200)]
        [Consumes(MediaTypes.FavoriteRegionModuleUpdateMediaType)]
        [Produces(MediaTypes.FavoriteRegionModuleMediaType)]
        [HttpPut("{favoriteRegionId}", Name = RouteNames.UpdateFavoriteRegion)]
        public async Task<IActionResult> UpdateFavoriteRegionAsync(UpdateFavoriteRegionCommand command)
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
            if (commandResult.ResultType == CommandResultType.NotFound)
            {
                return NotFound();
            }

            _linkGenerator.GenerateLinks(commandResult.Result);
            return Ok(commandResult.Result);
        }

        /// <summary>
        /// Updates favorite region for the favorite region module
        /// </summary>
        /// <response code="200">Returns the updated favorite region</response>
        /// <response code="404">When the favorite region does not exist</response>
        /// <response code="409">When the favorite region name already exist/invalid favorite region type</response>
        /// <response code="422">When the model structure is correct but validation fails</response>
        [SwaggerOperation(Tags = new[] { "FavoriteRegion/FavoriteRegion" })]
        [ProducesResponseType(typeof(bool), 200)]
        [Consumes(MediaTypes.FavoriteRegionModuleUpdateMediaType)]
        [Produces(MediaTypes.FavoriteRegionModuleMediaType)]
        [HttpDelete("{favoriteRegionId}", Name = RouteNames.DeleteFavoriteRegion)]
        public async Task<IActionResult> DeleteFavoriteRegionAsync(DeleteFavoriteRegionCommand command)
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
            if (commandResult.ResultType == CommandResultType.NotFound)
            {
                return NotFound();
            }
           
            return Ok(commandResult.Result);
        }
    }
}
