using GPUHunt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace GPUHunt.Infrastructure.Configuration
{
    public class GraphicCardConfiguration : IEntityTypeConfiguration<GraphicCard>
    {
        public void Configure(EntityTypeBuilder<GraphicCard> builder)
        {
            builder.Property(g => g.Model)
            .IsRequired();

            builder.HasOne(g => g.Subvendor)
            .WithMany(s => s.GraphicCards)
            .HasForeignKey(g => g.SubvendorId);

            builder.HasMany(g => g.FavouriteCards)
                .WithMany(l => l.GraphicCards);
        }
    }
}
