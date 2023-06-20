using Microsoft.AspNetCore.Authorization;

namespace Vculp.Api.Authorization
{
    public class UserHasApplicationPermissionRequirement : IAuthorizationRequirement
    {
        public UserHasApplicationPermissionRequirement(string permissionKey) =>
            PermissionKey = permissionKey;

        public string PermissionKey { get; }
    }
}