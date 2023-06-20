using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vculp.Api.Data.EntityFramework.Common;
using Vculp.Api.Domain.Core.Rbac;

namespace Vculp.Api.Data.EntityFramework.Rbac.Configurations
{
    public class UserConfiguration : EntityConfiguration<User>
    {
        public UserConfiguration(CoreContext context)
            : base(context)
        {
        }

        protected override string SchemaName => "Rbac";

        protected override string TableName => "Users";

        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.ExternalUserId)
                   .IsRequired();

            builder.HasIndex(u => u.ExternalUserId)
                   .IsUnique();

            builder.Property(u => u.FirstName)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(u => u.LastName)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(u => u.DisplayName)
                   .HasMaxLength(110)
                   .IsRequired();
        }
    }
}
