using AqarPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AqarPlatform.Persistence.Configurations.CityConfigration
{
    public class CityConfg : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(c=>c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(c => c.Properties)
                   .WithOne(p => p.City)
                   .HasForeignKey(p => p.CityId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
