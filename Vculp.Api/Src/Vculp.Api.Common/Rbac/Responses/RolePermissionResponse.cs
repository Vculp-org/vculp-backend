using System;
using Newtonsoft.Json;
using Vculp.Api.Common.Common.Dtos;

namespace Vculp.Api.Common.Rbac.Responses
{
    public class RolePermissionResponse : LinkedResourceDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [JsonIgnore]
        public Guid RoleId { get; set; }
        [JsonIgnore]
        public Guid ApplicationPermissionId { get; set; }
        public string Name { get; set; }
        public string PermissionKey { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
    }
}
