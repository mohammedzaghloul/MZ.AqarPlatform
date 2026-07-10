using AqarPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AqarPlatform.Persistence.Configurations.PropertyStatusConfiguration
{
    public class PropertyStatusConfg : IEntityTypeConfiguration<PropertyStatus>
    {
        public void Configure(EntityTypeBuilder<PropertyStatus> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasMany(x => x.Properties)
                .WithOne(p => p.Status)
                .HasForeignKey(x => x.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
