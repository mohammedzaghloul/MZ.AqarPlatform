using AqarPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AqarPlatform.Persistence.Configurations.FeatureConfiguration
{
    public class FeatureConfg : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(f=>f.Name)
                   .IsRequired()
                   .HasMaxLength(200);
        }
    }
}
