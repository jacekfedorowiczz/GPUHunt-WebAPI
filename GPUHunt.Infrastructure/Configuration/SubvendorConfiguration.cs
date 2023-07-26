using GPUHunt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPUHunt.Infrastructure.Configuration
{
    public class SubvendorConfiguration : IEntityTypeConfiguration<Domain.Entities.Subvendor>
    {
        public void Configure(EntityTypeBuilder<Subvendor> builder)
        {
            builder.Property(sv => sv.Name)
                .IsRequired();
        }
    }
}
