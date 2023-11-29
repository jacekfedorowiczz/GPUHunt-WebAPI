using GPUHunt.Domain.Entities;
using GPUHunt.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace GPUHunt.Infrastructure.Persistance
{
    public class GPUHuntDbContext : DbContext
    {
        public GPUHuntDbContext(DbContextOptions<GPUHuntDbContext> options) : base(options)
        {
            
        }

        public DbSet<GPUHunt.Domain.Entities.GraphicCard> GraphicCards { get; set; }
        public DbSet<GPUHunt.Domain.Entities.Prices> Prices { get; set; }
        public DbSet<GPUHunt.Domain.Entities.Store> Stores { get; set; }
        public DbSet<GPUHunt.Domain.Entities.Vendor> Vendors { get; set; }
        public DbSet<GPUHunt.Domain.Entities.Subvendor> Subvendors { get; set; }
        public DbSet<GPUHunt.Domain.Entities.Account> Accounts { get; set; }
        public DbSet<GPUHunt.Domain.Entities.Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GraphicCardConfiguration).Assembly);

            modelBuilder.Entity<GraphicCard>()
                .HasOne(g => g.Subvendor)
                .WithMany(s => s.GraphicCards)
                .HasForeignKey(g => g.SubvendorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
