using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vculp.Api.Domain.Interfaces.Common;

namespace Vculp.Api.Domain.Interfaces.FavoriteRegion
{
    public interface IFavoriteRegionRepository : IRepository<Core.FavoriteRegion.FavoriteRegion>
    {
        Task<bool> ExistWithNameAsync(string name);
    }
}
