using GPUHunt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GPUHunt.Infrastructure.Configuration
{
    public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.Property(v => v.Name)
                .IsRequired();

            builder.HasMany(v => v.GraphicCards)
                .WithOne(g => g.Vendor)
                .HasForeignKey(g => g.VendorId);
        }
    }
}
