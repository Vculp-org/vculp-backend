using System;
using Newtonsoft.Json;
using Vculp.Api.Common.Common.Dtos;

namespace Vculp.Api.Common.Rbac.Responses
{
    public class RoleMemberResponse : LinkedResourceDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [JsonIgnore]
        public Guid RoleId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
    }
}
