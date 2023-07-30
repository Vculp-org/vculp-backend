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
using Vculp.Api.Common.User.Commands;


namespace Vculp.Api.User.Controllers
{
    [Area("User")]
    [Route("users-api/users")]
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class UserControllers : PagedCollectionController
    {
        private readonly IMediator _mediator;
        private readonly IHateoasLinkGenerator<UserResponse> _linkGenerator;

        public UserControllers(IMediator mediator, IHateoasLinkGenerator<UserResponse> linkGenerator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _linkGenerator = linkGenerator ?? throw new ArgumentNullException(nameof(linkGenerator));

        }

        /// <summary>
        /// Creates a new User
        /// </summary>
        /// <response code="201">Returns created User</response>
        /// <response code="400">When a model with invalid structure is supplied</response>
        /// <response code="409">When the user name is already in use</response>
        /// <response code="422">When the model structure is correct but validation fails</response>
        [SwaggerOperation(Tags = new[] { "User/Users" })]
        [ProducesResponseType(typeof(UserResponse), 201)]
        [Consumes(MediaTypes.UserModuleCreateUserV1MediaType)]
        [Produces(MediaTypes.UserModuleUserV1MediaType)]
        [HttpPost(Name = RouteNames.UserCreateUser)]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserCommand command)
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

            _linkGenerator.GenerateLinks(commandResult.Result);

            return CreatedAtRoute(
                RouteNames.UserGetUserById,
                new UserQuery() { UserId = commandResult.Result.UserId },
                commandResult.Result);
        }
        
        /// <summary>
        /// Gets all Users.
        /// </summary>
        [SwaggerOperation(Tags = new[] { "User/Users" })]
        [ProducesResponseType(typeof(LinkedCollectionResourceWrapperDto<UserResponse>), 200)]
        [Produces(MediaTypes.UserModuleUserV1MediaType)]
        [HttpGet(Name = RouteNames.UserGetAllUsers)]
        public async Task<IActionResult> GetAllUsersAsync(UsersQuery query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userResponses = await _mediator.Send(query);

            foreach (var userResponse in userResponses)
            {
                _linkGenerator.GenerateLinks(userResponse);
            }

            GeneratePagingHeaders(new PagingMetadata
            {
                TotalItems = userResponses.TotalItems,
                TotalPages = userResponses.TotalPages,
                CurrentPage = userResponses.CurrentPage,
                PageSize = userResponses.PageSize
            });

            var wrapper = new LinkedCollectionResourceWrapperDto<UserResponse>(userResponses);

            wrapper = CreateHateoasLinksForCollection(wrapper, query, userResponses.HasNext, userResponses.HasPrevious);

            wrapper.Links.Add(
                new LinkDto(
                    Url.Link(RouteNames.UserCreateUser, new { }),
                    "create-contract",
                    HttpMethod.Post.Method));

            return Ok(wrapper);
        }

        /// <summary>
        /// Get User by Id.
        /// </summary>
        [SwaggerOperation(Tags = new[] { "User/Users" })]
        [ProducesResponseType(typeof(LinkedCollectionResourceWrapperDto<UserResponse>), 200)]
        [Produces(MediaTypes.UserModuleUserV1MediaType)]
        [HttpGet("{userId}", Name = RouteNames.UserGetUserById)]
        public async Task<IActionResult> GetUserByIdAsync(UserQuery query)
        {
            var userResponse = await _mediator.Send(query);

            if (userResponse == null)
            {
                return NotFound();
            }

            _linkGenerator.GenerateLinks(userResponse);

            return Ok(userResponse);
        }
        
        
        /// <summary>
        /// Updates a user for the user module
        /// </summary>
        /// <response code="200">Returns the updated user</response>
        /// <response code="404">When the user does not exist</response>
        /// <response code="409">When the user name already exist/invalid user type</response>
        /// <response code="422">When the model structure is correct but validation fails</response>
        [SwaggerOperation(Tags = new[] { "User/Users" })]
        [ProducesResponseType(typeof(UserResponse), 200)]
        [Consumes(MediaTypes.UserModuleUpdateV1MediaType)]
        [Produces(MediaTypes.UserModuleUserV1MediaType)]
        [HttpPut("{userid}", Name = RouteNames.UserUpdateUserById)]
        public async Task<IActionResult> UpdateUserAsync(UpdateUserCommand command)
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

    }
}