using Vculp.Api.Common.Common;
using Vculp.Api.Common.Rbac.Responses;

namespace Vculp.Api.Rbac.Helpers
{
    public class UserLinkGenerator : IHateoasLinkGenerator<UserResponse>
    {
        public UserResponse GenerateLinks(UserResponse dto)
        {
            return dto;
        }
    }
}
