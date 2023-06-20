using Microsoft.Extensions.DependencyInjection;

namespace Vculp.Api
{
    public static partial class ServiceCollectionExtensions
    {
        public static void BootstrapRbacDependecies(this IServiceCollection services)
        {
            #region Link Generators

            // services.AddTransient<IHateoasLinkGenerator<ApplicationPermissionResponse>, ApplicationPermissionLinkGenerator>();
            // services.AddTransient<IHateoasLinkGenerator<UserResponse>, UserLinkGenerator>();
            // services.AddTransient<IHateoasLinkGenerator<RoleResponse>, RoleLinkGenerator>();
            // services.AddTransient<IHateoasLinkGenerator<RoleMemberResponse>, RoleMemberLinkGenerator>();
            // services.AddTransient<IHateoasLinkGenerator<RolePermissionResponse>, RolePermissionLinkGenerator>();

            #endregion
        }
    }
}
