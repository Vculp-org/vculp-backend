using Microsoft.AspNetCore.Authorization;

namespace Vculp.Api.AuthorizationPolicies
{
    public class UserHasApplicationPermissionRequirement : IAuthorizationRequirement
    {
        public UserHasApplicationPermissionRequirement(string permissionKey) =>
            PermissionKey = permissionKey;

        public string PermissionKey { get; }
    }
}