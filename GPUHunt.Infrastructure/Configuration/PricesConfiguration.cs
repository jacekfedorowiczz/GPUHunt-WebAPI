using GPUHunt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GPUHunt.Infrastructure.Configuration
{
    internal class StorePricesConfiguration : IEntityTypeConfiguration<Domain.Entities.Prices>
    {
        public void Configure(EntityTypeBuilder<Prices> builder)
        {
            builder.Property(p => p.CrawlTime)
                .ValueGeneratedOnAddOrUpdate();

            builder.Property(p => p.MoreleLowestPriceEverCrawlDate)
                .ValueGeneratedOnAddOrUpdate();

            builder.Property(p => p.MoreleHighestPriceEverCrawlDate)
                .ValueGeneratedOnAddOrUpdate();

            builder.Property(p => p.XkomLowestPriceEverCrawlDate)
                .ValueGeneratedOnAddOrUpdate();

            builder.Property(p => p.XkomHighestPriceEverCrawlDate)
                .ValueGeneratedOnAddOrUpdate();

            builder.Property(p => p.MoreleActualPrice)
                .HasPrecision(7, 2);

            builder.Property(p => p.XKomActualPrice)
                .HasPrecision(7, 2);

            builder.Property(p => p.LowestPrice)
                .IsRequired()
                .HasPrecision(7, 2);
                
            builder.Property(p => p.HighestPrice)
                .HasPrecision(7, 2);

            builder.Property(p => p.MoreleLowestPriceEver)
                .HasPrecision(7, 2);

            builder.Property(p => p.LowestPriceEverXkom)
                .HasPrecision(7, 2);

            builder.Property(p => p.MoreleHighestPriceEver)
                .HasPrecision(7, 2);

            builder.Property(p => p.XkomHighestPriceEver)
                .HasPrecision(7, 2);
        }
    }
}
