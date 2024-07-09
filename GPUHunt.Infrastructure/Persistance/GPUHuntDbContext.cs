using GPUHunt.Domain.Entities;
using GPUHunt.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace GPUHunt.Infrastructure.Persistance
{
    public class GPUHuntDbContext : DbContext
    {
        public GPUHuntDbContext(DbContextOptions<GPUHuntDbContext> options) : base(options) { }

        public DbSet<GraphicCard> GraphicCards { get; set; }
        public DbSet<Prices> Prices { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Subvendor> Subvendors { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GraphicCardConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
