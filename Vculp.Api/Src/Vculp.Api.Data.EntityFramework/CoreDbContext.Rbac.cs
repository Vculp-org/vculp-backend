using Microsoft.EntityFrameworkCore;
using Vculp.Api.Data.EntityFramework.Rbac.Configurations;
using Vculp.Api.Domain.Core.Rbac;

namespace Vculp.Api.Data.EntityFramework
{
    public partial class CoreContext : DbContext
    {
        public DbSet<ApplicationPermission> ApplicationPermissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleMember> RoleMembers { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<User> Users { get; set; }

        public void OnRbacModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationPermissionConfiguration(this));
            modelBuilder.ApplyConfiguration(new RoleConfiguration(this));
            modelBuilder.ApplyConfiguration(new RoleMemberConfiguration(this));
            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(this));
            modelBuilder.ApplyConfiguration(new UserConfiguration(this));
        }
    }
}
