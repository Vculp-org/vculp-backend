using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vculp.Api.Domain.Interfaces.Common;

namespace Vculp.Api.Data.EntityFramework.Common.UnitOfWork
{
    public class CommitChangesUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public CommitChangesUnitOfWork(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
