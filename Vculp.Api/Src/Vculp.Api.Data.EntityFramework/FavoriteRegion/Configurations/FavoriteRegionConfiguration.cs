using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vculp.Api.Data.EntityFramework.Common;

namespace Vculp.Api.Data.EntityFramework.FavoriteRegion.Configurations
{
    public class FavoriteRegionConfiguration : EntityConfiguration<Domain.Core.FavoriteRegion.FavoriteRegion>
    {
        public FavoriteRegionConfiguration(CoreContext context) : base(context)
        {
        }

        protected override string SchemaName => "FavoriteRegion";

        protected override string TableName => "FavoriteRegions";

        public override void Configure(EntityTypeBuilder<Domain.Core.FavoriteRegion.FavoriteRegion> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.Name)
                .IsRequired();

            builder.Property(r => r.AreaName)
                .IsRequired();

            builder.Property(r => r.Latitude)
                .IsRequired();

            builder.Property(r => r.Longitude)
               .IsRequired();

            builder.Property(r => r.Radius)
                .IsRequired();

            builder.Property(r => r.IsActive)
                .IsRequired();

           

        }
    }
}
