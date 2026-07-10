using AqarPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AqarPlatform.Persistence.Configurations.FavoriteConfigurations
{
    internal class FavoriteConfg : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(f=> f.User)
                   .WithMany(u=> u.Favorites)
                   .HasForeignKey(f=>f.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(f => f.Property)
                   .WithMany(f => f.Favorites)
                   .HasForeignKey(f => f.PropertyId)
                   .OnDelete(DeleteBehavior.Cascade);
       
        }
    }
}
