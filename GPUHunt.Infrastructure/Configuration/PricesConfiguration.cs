using GPUHunt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GPUHunt.Infrastructure.Configuration
{
    internal class StorePricesConfiguration : IEntityTypeConfiguration<Prices>
    {
        public void Configure(EntityTypeBuilder<Prices> builder)
        {
            builder.Property(p => p.MoreleActualPrice)
                .HasPrecision(7, 2);

            builder.Property(p => p.XKomActualPrice)
                .HasPrecision(7, 2);

            builder.Property(p => p.MoreleLowestPriceEver)
                .HasPrecision(7, 2);

            builder.Property(p => p.XkomLowestPriceEver)
                .HasPrecision(7, 2);

            builder.Property(p => p.MoreleHighestPriceEver)
                .HasPrecision(7, 2);

            builder.Property(p => p.XkomHighestPriceEver)
                .HasPrecision(7, 2);
        }
    }
}
