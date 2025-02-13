using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CityConnect.Domain.Models;

namespace CityConnect.Domain
{
    public partial class CityConnectContext : IdentityDbContext<ApplicationUser>
    {
        public CityConnectContext(DbContextOptions<CityConnectContext> options) : base(options)
        {
        }

        public DbSet<AccessModule> AccessModule { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RoleModule> RoleModule { get; set; }
        public virtual DbSet<AccessModule> AccessModules { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Role> AccessRoles { get; set; }
        public virtual DbSet<RoleModule> RoleModules { get; set; }
    }
}