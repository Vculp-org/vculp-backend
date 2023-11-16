using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vculp.Api.Data.EntityFramework.Common;
using Vculp.Api.Domain.Interfaces.FavoriteRegion;
using Vculp.Api.Domain.Interfaces.User;

namespace Vculp.Api.Data.EntityFramework.FavoriteRegion.Repositories
{
    public class FavoriteRegionRepository : Repository<Domain.Core.FavoriteRegion.FavoriteRegion>, IFavoriteRegionRepository
    {
        public FavoriteRegionRepository(CoreContext context) : base(context)
        {
        }

        public async Task<bool> ExistWithNameAsync(string name)
        {
           return await IncludeAll().AnyAsync(q => q.Name == name);
        }

        protected override IQueryable<Domain.Core.FavoriteRegion.FavoriteRegion> IncludeAll()
        {
            return DbSet;
        }
    }
}
