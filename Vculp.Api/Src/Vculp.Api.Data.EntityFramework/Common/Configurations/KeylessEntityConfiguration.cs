using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vculp.Api.Data.EntityFramework.Common.Configurations
{
    public abstract class KeylessEntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : KeylessEntity<T>
    {
        public KeylessEntityConfiguration(CoreContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected CoreContext Context { get; }

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasNoKey();

            builder.HasQueryFilter(Context.CreateDefaultGlobalQueryFilter<T>());
        }
    }
}
