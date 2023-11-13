using GPUHunt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GPUHunt.Infrastructure.Configuration
{
    public class SubvendorConfiguration : IEntityTypeConfiguration<Subvendor>
    {
        public void Configure(EntityTypeBuilder<Subvendor> builder)
        {
            builder.Property(sv => sv.Name)
                .IsRequired();
        }
    }
}
