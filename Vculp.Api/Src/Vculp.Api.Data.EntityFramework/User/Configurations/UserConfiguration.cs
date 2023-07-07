using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vculp.Api.Data.EntityFramework.Common;

namespace Vculp.Api.Data.EntityFramework.User.Configurations;

public class UserConfiguration : EntityConfiguration<Domain.Core.User.User>
{
    public UserConfiguration(CoreContext context) : base(context)
    {
    }

    protected override string SchemaName => "User";

    protected override string TableName => "Users";

    public override void Configure(EntityTypeBuilder<Domain.Core.User.User> builder)
    {
        base.Configure(builder);

        builder.Property(u => u.ExternalUserId)
            .IsRequired();
        builder.HasIndex(u => u.ExternalUserId)
            .IsUnique();

        builder.Property(r => r.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(r => r.LastName)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(r => r.EmailAddress)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(r => r.MobileNumber)
            .HasMaxLength(20)
            .IsRequired();
        
        builder.HasIndex(r => r.MobileNumber)
            .IsUnique();
        
        
    }
}