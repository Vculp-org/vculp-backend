using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vculp.Api.Data.EntityFramework.Extensions;
using Vculp.Api.Domain.Core.SharedKernel;
using Vculp.Api.Domain.Core.SharedKernel.Interfaces;

namespace Vculp.Api.Data.EntityFramework.Common
{
    public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : Entity
    {
        public EntityConfiguration(CoreContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected CoreContext Context { get; }
        protected abstract string SchemaName { get; }
        protected abstract string TableName { get; }

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            if (string.IsNullOrWhiteSpace(SchemaName))
            {
                throw new InvalidOperationException($"{nameof(SchemaName)} must be set.");
            }

            if (string.IsNullOrWhiteSpace(TableName))
            {
                throw new InvalidOperationException($"{nameof(TableName)} must be set.");
            }

            builder.ToTable(TableName, SchemaName);

            builder.Property(e => e.Id)
                   .ValueGeneratedNever();

            builder.Property<int>("ClusterId")
                   .UseIdentityColumn();

            builder.HasIndex("ClusterId")
                   .HasDatabaseName($"IX_{TableName}_ClusterId")
                   .IsUnique()
                   .IsClustered();

            builder.Property<int>("ClusterId")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder.HasKey(e => e.Id)
                   .IsClustered(false);

            builder.Property<bool>("IsDeleted");
            builder.HasIndex("IsDeleted")
                   .HasDatabaseName($"IX_{TableName}_IsDeleted");

            builder.Ignore(e => e.State);

            builder.HasQueryFilter(Context.CreateDefaultGlobalQueryFilter<T>());

            if (typeof(ICreationAuditable).IsAssignableFrom(builder.Metadata.ClrType))
            {
                builder.Property<DateTime>(nameof(ICreationAuditable.CreationTime))
                       .HasColumnName("CreationTime")
                       .IsRequired()
                       .HasDefaultValueSql(Context.DefaultDateTimeUtcExpression())
                       .HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
                       .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            }

            if (typeof(IUpdateAuditable).IsAssignableFrom(builder.Metadata.ClrType))
            {
                builder.Property<DateTime>(nameof(IUpdateAuditable.LastUpdated))
                       .HasColumnName("LastUpdated")
                       .IsRequired()
                       .HasDefaultValueSql(Context.DefaultDateTimeUtcExpression())
                       .HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
            }
        }
    }
}
