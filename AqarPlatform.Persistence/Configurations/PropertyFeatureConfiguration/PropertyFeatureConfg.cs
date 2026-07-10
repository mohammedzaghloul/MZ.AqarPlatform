using AqarPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AqarPlatform.Persistence.Configurations.PropertyFeatureConfiguration
{
    public class PropertyFeatureConfg : IEntityTypeConfiguration<PropertyFeature>
    {
        public void Configure(EntityTypeBuilder<PropertyFeature> builder)
        {
            builder.HasKey(n => new {n.FeatureId,n.PropertyId});
            builder.HasOne(pf => pf.Property)
                .WithMany(p => p.PropertyFeatures)
                .HasForeignKey(pf => pf.PropertyId);

            builder.HasOne(pf => pf.Feature)
                .WithMany(f => f.PropertyFeatures)
                .HasForeignKey(pf => pf.FeatureId);
        }
    }
}
