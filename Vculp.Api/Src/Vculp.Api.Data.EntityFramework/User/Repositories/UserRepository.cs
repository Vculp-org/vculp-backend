using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vculp.Api.Data.EntityFramework.Common;
using Vculp.Api.Domain.Interfaces.User;

namespace Vculp.Api.Data.EntityFramework.User.Repositories;

public class UserRepository : Repository<Domain.Core.User.User>, IUserRepository
{
    public UserRepository(CoreContext context) : base(context)
    {
    }

    protected override IQueryable<Domain.Core.User.User> IncludeAll()
    {
        return DbSet;
    }

    public async Task<Domain.Core.User.User> GetByEmailAsync(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(email));
        return await IncludeAll().FirstOrDefaultAsync(x => x.EmailAddress == email);
    }

    public async Task<Domain.Core.User.User> GetByMobileAsync(string mobile)
    {
        if (string.IsNullOrWhiteSpace(mobile))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(mobile));
        return await IncludeAll().FirstOrDefaultAsync(x => x.MobileNumber == mobile);
    }

    public async Task<bool> ExistAsync(string mobile)
    {
        return await IncludeAll().AnyAsync(q => q.MobileNumber == mobile);
    }

    public async Task<bool> ExistWithEmailAsync(string email)
    {
        return await IncludeAll().AnyAsync(q => q.EmailAddress == email);
    }
}