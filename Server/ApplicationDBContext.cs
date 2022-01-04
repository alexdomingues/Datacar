using Datacar.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Datacar.Server
{
    public class ApplicationDBContext: IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Cars> Cars { get; set; }
        public DbSet<Drivers> Drivers { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<TestEntity> TestEntities { get; set; }
    }
}
