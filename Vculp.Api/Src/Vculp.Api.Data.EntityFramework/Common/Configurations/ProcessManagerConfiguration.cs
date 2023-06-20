using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vculp.Api.Common.Common;

namespace Vculp.Api.Data.EntityFramework.Common.Configurations
{
    public abstract class ProcessManagerConfiguration<T> : IEntityTypeConfiguration<T>
        where T : ProcessManager
    {
        public ProcessManagerConfiguration(CoreContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected CoreContext Context { get; private set; }

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property<int>("ClusterId")
                   .UseIdentityColumn();

            builder.HasIndex("ClusterId")
                   .IsUnique()
                   .IsClustered();

            builder.Property<int>("ClusterId")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder.Ignore(p => p.CommandsToSend);
        }
    }
}
