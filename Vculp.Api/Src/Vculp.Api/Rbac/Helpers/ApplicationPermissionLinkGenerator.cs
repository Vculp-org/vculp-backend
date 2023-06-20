using Vculp.Api.Common.Common;
using Vculp.Api.Common.Rbac.Responses;

namespace Vculp.Api.Rbac.Helpers
{
    public class ApplicationPermissionLinkGenerator : IHateoasLinkGenerator<ApplicationPermissionResponse>
    {
        public ApplicationPermissionResponse GenerateLinks(ApplicationPermissionResponse dto)
        {
            return dto;
        }
    }
}
