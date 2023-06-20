using System;
using Vculp.Api.Common.Common.Dtos;

namespace Vculp.Api.Common.Rbac.Responses
{
    public class ApplicationPermissionResponse : LinkedResourceDto
    {
        public Guid ApplicationPermissionId { get; set; }
        public string PermissionKey { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
    }
}
