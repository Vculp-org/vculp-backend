using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vculp.Api.Data.EntityFramework.Common;
using Vculp.Api.Domain.Core.Rbac;

namespace Vculp.Api.Data.EntityFramework.Rbac.Configurations
{
    public class RolePermissionConfiguration : EntityConfiguration<RolePermission>
    {
        public RolePermissionConfiguration(CoreContext context)
            : base(context)
        {
        }

        protected override string SchemaName => "Rbac";

        protected override string TableName => "RolePermissions";

        public override void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            base.Configure(builder);

            builder.HasOne<Role>()
                   .WithMany()
                   .IsRequired()
                   .HasForeignKey(p => p.RoleId);

            builder.HasOne<ApplicationPermission>()
                   .WithMany()
                   .IsRequired()
                   .HasForeignKey(p => p.ApplicationPermissionId);
        }
    }
}
