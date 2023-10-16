using System.Linq;
using Vculp.Api.Data.EntityFramework.Common;
using Vculp.Api.Domain.Core.Location;
using Vculp.Api.Domain.Interfaces.Location;

namespace Vculp.Api.Data.EntityFramework.Location.Repositories;

public class FavoriteLocationRepository: Repository<FavoriteLocation>, IFavoriteLocationRepository
{
    public FavoriteLocationRepository(CoreContext context) : base(context)
    {
    }

    protected override IQueryable<FavoriteLocation> IncludeAll()
    {
        return DbSet;
    }
}