using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Vculp.Api.Common.Common;

namespace Vculp.Api.AuthorizationPolicies
{
    // public class UserHasApplicationPermissionHandler : AuthorizationHandler<UserHasApplicationPermissionRequirement>
    // {
    //     private readonly IApplicationPermissionRepository _applicationPermissionRepository;
    //     private readonly ICurrentUserAccessor _currentUserAccessor;
    //
    //     public UserHasApplicationPermissionHandler
    //     (
    //         IApplicationPermissionRepository applicationPermissionRepository,
    //         ICurrentUserAccessor currentUserAccessor
    //     )
    //     {
    //         _applicationPermissionRepository = applicationPermissionRepository ??
    //                                            throw new ArgumentNullException(nameof(applicationPermissionRepository));
    //         _currentUserAccessor = currentUserAccessor ?? throw new ArgumentNullException(nameof(currentUserAccessor));
    //     }
    //
    //     protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
    //         UserHasApplicationPermissionRequirement requirement)
    //     {
    //         if (context == null)
    //         {
    //             throw new ArgumentNullException(nameof(context));
    //         }
    //
    //         if (requirement == null)
    //         {
    //             throw new ArgumentNullException(nameof(requirement));
    //         }
    //
    //         var applicationPermission =
    //             (await _applicationPermissionRepository.GetForExternalUserId(_currentUserAccessor.UserId.Value))
    //             .ToList();
    //
    //         if (!applicationPermission.Any())
    //         {
    //             context.Fail();
    //         }
    //         else
    //         {
    //             if (applicationPermission.Any(q => q.PermissionKey == "GlobalAdministrator"))
    //             {
    //                 context.Succeed(requirement);
    //             }
    //             else if (applicationPermission.Any(q => q.PermissionKey == requirement.PermissionKey))
    //             {
    //                 context.Succeed(requirement);
    //             }
    //             else
    //             {
    //                 context.Fail();
    //             }
    //         }
    //     }
    // }
}