using System;
using Vculp.Api.Common.Common.Dtos;

namespace Vculp.Api.Common.Rbac.Responses
{
    public class RoleResponse : LinkedResourceDto
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
