using GPUHunt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GPUHunt.Infrastructure.Configuration
{
    public class GraphicCardConfiguration : IEntityTypeConfiguration<GraphicCard>
    {
        public void Configure(EntityTypeBuilder<GraphicCard> builder)
        {
            builder.Property(g => g.Model)
                .IsRequired();
        }
    }
}
