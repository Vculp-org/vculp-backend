using Microsoft.AspNetCore.Authorization;

namespace Vculp.Api.Authorization
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