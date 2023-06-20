using System.Linq;
using Vculp.Api.Data.EntityFramework.Common;
using Vculp.Api.Domain.Core.Rbac;
using Vculp.Api.Domain.Interfaces.Rbac.Repositories;

namespace Vculp.Api.Data.EntityFramework.Rbac.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(CoreContext context)
           : base(context)
        {
        }

        protected override IQueryable<User> IncludeAll()
        {
            return DbSet;
        }
    }
}
