using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vculp.Api.Data.EntityFramework.Common;
using Vculp.Api.Domain.Core.Rbac;

namespace Vculp.Api.Data.EntityFramework.Rbac.Configurations
{
    public class ApplicationPermissionConfiguration : EntityConfiguration<ApplicationPermission>
    {
        public ApplicationPermissionConfiguration(CoreContext context)
            : base(context)
        {
        }

        protected override string SchemaName => "Rbac";

        protected override string TableName => "ApplicationPermissions";

        public override void Configure(EntityTypeBuilder<ApplicationPermission> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.PermissionKey)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(p => p.DisplayName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(p => p.Description)
                   .HasMaxLength(200)
                   .IsRequired();
        }
    }
}
