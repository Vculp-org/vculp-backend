using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vculp.Api.Data.EntityFramework.Common;
using Vculp.Api.Domain.Core.Rbac;

namespace Vculp.Api.Data.EntityFramework.Rbac.Configurations
{
    public class RoleMemberConfiguration : EntityConfiguration<RoleMember>
    {
        public RoleMemberConfiguration(CoreContext context)
            : base(context)
        {
        }

        protected override string SchemaName => "Rbac";

        protected override string TableName => "RoleMembers";

        public override void Configure(EntityTypeBuilder<RoleMember> builder)
        {
            base.Configure(builder);

            builder.HasOne<Role>()
                   .WithMany()
                   .IsRequired()
                   .HasForeignKey(m => m.RoleId);

            builder.HasOne<User>()
                   .WithMany()
                   .IsRequired()
                   .HasForeignKey(u => u.UserId);
        }
    }
}
