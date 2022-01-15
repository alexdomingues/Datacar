using Datacar.Shared.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Datacar.Server
{
    public class ApplicationDBContext: IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {

        }
        public DbSet<Cars> Cars { get; set; }
        public DbSet<Drivers> Drivers { get; set; }
        public DbSet<DatacarUser> DatacarUser { get; set; }
        public DbSet<TestEntity> TestEntities { get; set; }
    }
}
