using AqarPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AqarPlatform.Persistence.Configurations.AppUserConfiguration
{
    public class UserConfg : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u=>u.UserName)    
                .HasMaxLength(30);

            builder.Property(u => u.Email)
               .HasMaxLength(50);

            builder.Property(u => u.PhoneNumber)
              .IsRequired()
              .HasMaxLength(50);

            builder.Property(u=>u.FullName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.ProfileImage)
                .HasMaxLength(150);

            builder.HasMany(u => u.Properties)
                .WithOne(p => p.Owner)
                .HasForeignKey(p => p.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
