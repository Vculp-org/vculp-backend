using System;
using Vculp.Api.Common.Common.Dtos;

namespace Vculp.Api.Common.Rbac.Responses
{
    public class UserResponse : LinkedResourceDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
    }
}
