using AqarPlatform.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AqarPlatform.Persistence.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    { 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        #region DbSet
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyFeature> PropertyFeatures { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }
        public DbSet<PropertyStatus> PropertyStatuses { get; set; }
        public DbSet<Review> Reviews { get; set; } 
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}