using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vculp.Api.Domain.Core.SharedKernel;

namespace Vculp.Api.Data.EntityFramework.Common
{
    public abstract class ValueObjectConfiguration<T> : IEntityTypeConfiguration<T>
        where T : ValueObject<T>
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property<int>("ClusterId")
                   .UseIdentityColumn();

            builder.Property<int>("ClusterId")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder.HasIndex("ClusterId")
                   .IsUnique()
                   .IsClustered();

            builder.Ignore(e => e.State);
        }
    }
}
