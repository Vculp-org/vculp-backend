using System;
using System.Net.Http;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vculp.Api.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Common.Dtos;
using Vculp.Api.Common.Rbac.Commands;
using Vculp.Api.Common.Rbac.Queries;
using Vculp.Api.Common.Rbac.Responses;
using Vculp.Api.Shared;

namespace Vculp.Api.Rbac.Controllers
{
    [Authorize]
    [Route("rbac/roles")]
    public class RolesController : PagedCollectionController
    {
        private readonly IMediator _mediator;
        private readonly IHateoasLinkGenerator<RoleResponse> _linkGenerator;
        private readonly IHateoasLinkGenerator<RoleMemberResponse> _linkGeneratorRoleMember;
        private readonly IHateoasLinkGenerator<RolePermissionResponse> _linkGeneratorRolePermission;

        public RolesController(
          IMediator mediator,
          IHateoasLinkGenerator<RoleResponse> linkGenerator,
          IHateoasLinkGenerator<RoleMemberResponse> linkGeneratorRoleMember,
          IHateoasLinkGenerator<RolePermissionResponse> linkGeneratorRolePermission)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _linkGenerator = linkGenerator ?? throw new ArgumentNullException(nameof(linkGenerator));
            _linkGeneratorRoleMember = linkGeneratorRoleMember ?? throw new ArgumentNullException(nameof(linkGeneratorRoleMember));
            _linkGeneratorRolePermission = linkGeneratorRolePermission ?? throw new ArgumentNullException(nameof(linkGeneratorRolePermission));
        }

        /// <summary>
        /// Gets all roles
        /// </summary>
        [ProducesResponseType(typeof(LinkedCollectionResourceWrapperDto<RoleResponse>), 200)]
        [Produces(MediaTypes.RbacRoleV1MediaType)]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(RolesQuery query)
        {
            var roles = await _mediator.Send(query);

            foreach (var role in roles)
            {
                _linkGenerator.GenerateLinks(role);
            }

            var pagedRoles = roles.ToPagedList(roles.TotalItems, (int)query.PageNumber, (int)query.PageSize);

            var wrapper = new LinkedCollectionResourceWrapperDto<RoleResponse>(pagedRoles);
            wrapper = CreateHateoasLinksForCollection(wrapper, query, pagedRoles.HasNext, pagedRoles.HasPrevious);

            wrapper.Links.Add(
                new LinkDto(
                    Url.Link(RouteNames.RbacCreateRole, new { }),
                    "create-role",
                    HttpMethod.Post.Method));

            return Ok(wrapper);
        }


        /// <summary>
        /// Gets role members for a role
        /// </summary>
        /// <response code="404">When role does not exist.</response>
        [ProducesResponseType(typeof(LinkedCollectionResourceWrapperDto<RoleMemberResponse>), 200)]
        [Produces(MediaTypes.RbacRoleMemberV1MediaType)]
        [HttpGet("{roleId}/role-members", Name = RouteNames.RbacGetRoleMembers)]
        public async Task<IActionResult> GetRoleMembersAsync(RoleMembersQuery query)
        {
            var roleMembers = await _mediator.Send(query);

            if (roleMembers == null)
            {
                return NotFound();
            }

            var pagedRoleMembers = roleMembers.ToPagedList(roleMembers.TotalItems, (int)query.PageNumber, (int)query.PageSize);

            foreach (var roleMember in pagedRoleMembers)
            {
                _linkGeneratorRoleMember.GenerateLinks(roleMember);
            }

            var wrapper = new LinkedCollectionResourceWrapperDto<RoleMemberResponse>(roleMembers);
            wrapper = CreateHateoasLinksForCollection(wrapper, query, pagedRoleMembers.HasNext, pagedRoleMembers.HasPrevious);

            wrapper.Links.Add(
                new LinkDto(
                    Url.Link(RouteNames.RbacAddUserToRole, new { RoleId = query.RoleId }),
                    "add-role-member",
                    HttpMethod.Post.Method));

            return Ok(wrapper);
        }

        /// <summary>
        /// Add user to a role
        /// </summary>
        /// <response code="404">When role does not exist.</response>
        /// <response code="404">When user does not exist.</response>
        /// <response code="409">When user is already a member of the role.</response>
        [ProducesResponseType(typeof(RoleMemberResponse), 200)]
        [Produces(MediaTypes.RbacRoleMemberV1MediaType)]
        [Consumes(MediaTypes.RbacModuleAddUserToRoleV1MediaType)]
        [HttpPost("{roleId}/role-members", Name = RouteNames.RbacAddUserToRole)]
        public async Task<IActionResult> AddUserToRoleAsync(AddUserToRoleCommand command)
        {
            if (command == null) { return BadRequest(); }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var commandResult = await _mediator.Send(command);

            if (commandResult.ResultType == CommandResultType.Conflict)
            {
                ModelState.AddModelErrors(commandResult.Errors);
                return Conflict(ModelState);
            }

            if (commandResult.ResultType == CommandResultType.NotFound)
            {
                return NotFound();
            }

            _linkGeneratorRoleMember.GenerateLinks(commandResult.Result);

            return Ok(commandResult.Result);
        }

        /// <summary>
        /// Remove a user from a role
        /// </summary>
        /// <response code="204">when role member is deleted successfully</response>
        /// <response code="404">When the role does not exist</response>
        /// <response code="404">When the role member is not is not is associated with role</response>
        [ProducesResponseType(204)]
        [HttpDelete("{roleId}/role-members/{roleMemberId}", Name = RouteNames.RbacRemoveUserFromRole)]
        public async Task<IActionResult> RemoveUserFromRoleAsync([FromRoute] DeleteUserFromRoleCommand command)
        {
            var commandResult = await _mediator.Send(command);

            if (commandResult.ResultType == CommandResultType.NotFound)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Gets role permissions for a role
        /// </summary>
        /// <response code="404">When role does not exist.</response>
        [ProducesResponseType(typeof(LinkedCollectionResourceWrapperDto<RolePermissionResponse>), 200)]
        [Produces(MediaTypes.RbacRolePermissionV1MediaType)]
        [HttpGet("{roleId}/role-permissions", Name = RouteNames.RbacGetRolePermissions)]
        public async Task<IActionResult> GetRolePermissionsAsync(RolePermissionsQuery query)
        {
            var rolePermissions = await _mediator.Send(query);

            if (rolePermissions == null)
            {
                return NotFound();
            }

            var pagedRolePermissions = rolePermissions.ToPagedList(rolePermissions.TotalItems, (int)query.PageNumber, (int)query.PageSize);

            foreach (var rolePermission in pagedRolePermissions)
            {
                _linkGeneratorRolePermission.GenerateLinks(rolePermission);
            }

            var wrapper = new LinkedCollectionResourceWrapperDto<RolePermissionResponse>(rolePermissions);
            wrapper = CreateHateoasLinksForCollection(wrapper, query, pagedRolePermissions.HasNext, pagedRolePermissions.HasPrevious);

            wrapper.Links.Add(
                new LinkDto(
                    Url.Link(RouteNames.RbacAddApplicationPermissionToRole, new { RoleId = query.RoleId }),
                    "add-role-permission",
                    HttpMethod.Post.Method));

            return Ok(wrapper);
        }


        /// <summary>
        /// Creates new role
        /// </summary>
        /// <response code="200">Returns created role</response>
        [ProducesResponseType(typeof(RoleResponse), 200)]
        [Produces(MediaTypes.RbacRoleV1MediaType)]
        [Consumes(MediaTypes.RbacModuleCreateRoleV1MediaType)]
        [HttpPost(Name = RouteNames.RbacCreateRole)]
        public async Task<IActionResult> AddRoleAsync([FromBody] CreateRoleCommand command)
        {
            if (command == null) { return BadRequest(); }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var commandResult = await _mediator.Send(command);

            if (commandResult.ResultType == CommandResultType.Conflict)
            {
                ModelState.AddModelErrors(commandResult.Errors);
                return Conflict(ModelState);
            }

            _linkGenerator.GenerateLinks(commandResult.Result);

            return Ok(commandResult.Result);
        }


        /// <summary>
        /// Updates a role
        /// </summary>
        /// <response code="200">Return the updated role</response>
        /// <response code="409">When a role name already exists</response>
        /// <response code="404">When the role does not exist</response>
        [ProducesResponseType(typeof(RoleResponse), 200)]
        [Consumes(MediaTypes.RbacModuleUpdateRoleV1MediaType)]
        [Produces(MediaTypes.RbacRoleV1MediaType)]
        [HttpPut("{roleId}", Name = RouteNames.RbacUpdateRole)]
        public async Task<IActionResult> UpdateRoleAsync(UpdateRoleCommand command)
        {
            if (command?.Body == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var commandResult = await _mediator.Send(command);

            if (commandResult.ResultType == CommandResultType.NotFound)
            {
                return NotFound();
            }

            if (commandResult.ResultType == CommandResultType.Conflict)
            {
                ModelState.AddModelErrors(commandResult.Errors);
                return Conflict(ModelState);
            }

            _linkGenerator.GenerateLinks(commandResult.Result);

            return Ok(commandResult.Result);
        }

        /// <summary>
        /// Adds an application permission to a role.
        /// </summary>
        /// <response code="200">When the application permission is added to the role successfully</response>
        /// <response code="422">When invalid structure is supplied</response>
        [ProducesResponseType(typeof(LinkedCollectionResourceWrapperDto<RolePermissionResponse>), 200)]
        [Consumes(MediaTypes.RbacModuleCreateApplicationPermissionV1MediaType)]
        [HttpPost("{roleId}/role-permissions", Name = RouteNames.RbacAddApplicationPermissionToRole)]
        public async Task<IActionResult> AddApplicationPermissionToRole(AddApplicationPermissionToRoleCommand command)
        {
            if (command?.Body == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var commandResult = await _mediator.Send(command);

            if (commandResult.ResultType == CommandResultType.NotFound)
            {
                return NotFound();
            }
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

            _linkGeneratorRolePermission.GenerateLinks(commandResult.Result);
            return Ok(commandResult.Result);
        }

        /// <summary>
        /// Removes an application permission from a role
        /// </summary>
        /// <response code="204">When an application permission is removed successfully</response>        
        /// <response code="404">When role or role permission not exists</response>
        [ProducesResponseType(204)]
        [Consumes(MediaTypes.RbacModuleDeleteApplicationPermissionV1MediaType)]
        [HttpDelete("{roleId}/role-permissions/{rolePermissionId}", Name = RouteNames.RbacRemoveApplicationPermissionFromRole)]
        public async Task<IActionResult> RemoveApplicationPermissionFromRole(RemoveApplicationPermissionFromRoleCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }
            if(command.RoleId == Guid.Empty || command.RolePermissionId == Guid.Empty)
            {
                return NotFound();
            }

            var response = await _mediator.Send(command);

            if (response.ResultType == CommandResultType.NotFound)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Remove a role
        /// </summary>
        /// <response code="204">when role is deleted successfully</response>
        /// <response code="404">When the role does not exist</response>
        [ProducesResponseType(204)]
        [HttpDelete("{roleId}", Name = RouteNames.RbacRemoveRole)]
        public async Task<IActionResult> RemoveRoleAsync([FromRoute] DeleteRoleCommand command)
        {
            var commandResult = await _mediator.Send(command);

            if (commandResult.ResultType == CommandResultType.NotFound)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
