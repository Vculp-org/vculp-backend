using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vculp.Api.Domain.Core.SharedKernel;

namespace Vculp.Api.Data.EntityFramework.Common
{
    public abstract class ActivatableEntityConfiguration<T> : EntityConfiguration<T>
        where T : ActivatableEntity
    {
        protected ActivatableEntityConfiguration(CoreContext context)
            : base(context)
        {
        }

        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.IsActive)
                   .HasDefaultValue(false);

            builder.HasIndex(e => e.IsActive)
                   .HasDatabaseName($"IX_{TableName}_IsActive");
        }
    }
}
