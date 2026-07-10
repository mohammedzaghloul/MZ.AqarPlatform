using AqarPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AqarPlatform.Persistence.Configurations.ReviewConfiguration
{
    public class ReviewConfg : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Rating)
                   .IsRequired();

            builder.Property(x => x.Comment)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.HasOne(x => x.Property)
                   .WithMany(x => x.Reviews)
                   .HasForeignKey(x => x.PropertyId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User)
                   .WithMany(x => x.Reviews)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
