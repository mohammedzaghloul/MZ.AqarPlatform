using AqarPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AqarPlatform.Persistence.Configurations.ContactMessageConfigration
{
    public class ContactMessageConfg : IEntityTypeConfiguration<ContactMessage>
    {
        public void Configure(EntityTypeBuilder<ContactMessage> builder)
        {
        builder.HasKey(x => x.Id);
        builder.Property(c=>c.Name)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(c => c.Email)
                   .IsRequired()
                   .HasMaxLength(70);

            builder.Property(c => c.Phone)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(c => c.Message)
                .IsRequired()
                .HasMaxLength(7000);

            builder.HasOne(c=>c.Property)
                .WithMany(p=>p.ContactMessages)
                .HasForeignKey(c=>c.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);       
        
        }
    }
    
}
