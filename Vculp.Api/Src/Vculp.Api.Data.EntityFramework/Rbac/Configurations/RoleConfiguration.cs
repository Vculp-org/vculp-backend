using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vculp.Api.Data.EntityFramework.Common;
using Vculp.Api.Domain.Core.Rbac;

namespace Vculp.Api.Data.EntityFramework.Rbac.Configurations
{
    public class RoleConfiguration : EntityConfiguration<Role>
    {
        public RoleConfiguration(CoreContext context)
            : base(context)
        {
        }

        protected override string SchemaName => "Rbac";

        protected override string TableName => "Roles";

        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);

            builder.Property(r => r.Name)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(r => r.Description)
                   .HasMaxLength(100)
                   .IsRequired();
        }
    }
}
