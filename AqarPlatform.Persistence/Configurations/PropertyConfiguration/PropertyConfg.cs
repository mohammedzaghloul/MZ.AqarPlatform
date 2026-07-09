using AqarPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AqarPlatform.Persistence.Configurations.PropertyConfiguration
{
    public class PropertyConfg : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(p => p.Price)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(p => p.Area)
                .HasPrecision(10, 2)
                .IsRequired();

            builder.Property(p => p.Bedrooms)
                .IsRequired();

            builder.Property(p => p.Bathrooms)
                .IsRequired();

            builder.Property(p => p.Floor)
                .IsRequired();

            builder.Property(p => p.Furnished)
                .HasDefaultValue(false);

            // realtion owner to property
            builder.HasOne(p => p.Owner)
                .WithMany(p => p.Properties)
                .HasForeignKey(p=>p.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

//============================================================
            builder.HasOne(p => p.Category)
            .WithMany(c => c.Properties)
            .HasForeignKey(p => p.CategoryId);

            builder.HasOne(p => p.City)
                .WithMany(c => c.Properties)
                .HasForeignKey(p => p.CityId);

            builder.HasOne(p => p.Status)
                .WithMany(s => s.Properties)
                .HasForeignKey(p => p.StatusId);

            builder.HasMany(p => p.Images)
                .WithOne(i => i.Property)
                .HasForeignKey(i => i.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
