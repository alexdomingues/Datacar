using Datacar.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Datacar.Server
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {

        }

        public DbSet<Cars> Cars { get; set; }
        public DbSet<Drivers> Drivers { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<TestEntity> TestEntities { get; set; }
    }
}
