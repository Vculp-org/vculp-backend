using Microsoft.AspNetCore.Authorization;

namespace Vculp.Api.AuthorizationPolicies
{
    public class UserHasApplicationPermissionAttribute : AuthorizeAttribute
    {
        private const string PolicyPrefix = "UserApplicationPermission";

        public UserHasApplicationPermissionAttribute(string permissionKey) => PermissionKey = permissionKey;

        public string PermissionKey
        {
            get => Policy;
            set => Policy = $"{PolicyPrefix}{value}";
        }

        
    }
}