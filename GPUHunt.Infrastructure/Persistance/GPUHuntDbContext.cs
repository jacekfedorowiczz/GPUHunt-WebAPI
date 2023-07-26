using GPUHunt.Domain.Entities;
using GPUHunt.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public DbSet<GPUHunt.Domain.Entities.Account> Accounts { get; set; }
        public DbSet<GPUHunt.Domain.Entities.Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GraphicCard>()
                .HasOne(g => g.Prices)
                .WithOne(p => p.GraphicCard)
                .HasForeignKey<Domain.Entities.Prices>(p => p.GraphicCardId);

            modelBuilder.Entity<GraphicCard>()
                .HasOne(g => g.Subvendor)
                .WithMany(sv => sv.GraphicCards)
                .HasForeignKey(g => g.SubvendorId);

            modelBuilder.Entity<GraphicCard>()
                .HasOne(g => g.Vendor)
                .WithMany(v => v.GraphicCards)
                .HasForeignKey(g => g.VendorId);


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GraphicCardConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
