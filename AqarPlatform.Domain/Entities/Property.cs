using AqarPlatform.Domain.Common;

namespace AqarPlatform.Domain.Entities
{
    public class Property : BaseEntity
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public decimal Area { get; set; }

        public int Bedrooms { get; set; }

        public int Bathrooms { get; set; }

        public int Floor { get; set; }

        public bool Furnished { get; set; }

        public Guid OwnerId { get; set; }

        public ApplicationUser Owner { get; set; } = null!;

        public Guid CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        public Guid CityId { get; set; }

        public City City { get; set; } = null!;

        public Guid StatusId { get; set; }

        public PropertyStatus Status { get; set; } = null!;

        public ICollection<PropertyImage> Images { get; set; } = [];

        public ICollection<PropertyFeature> PropertyFeatures { get; set; } = [];

        public ICollection<Favorite> Favorites { get; set; } = [];
        public ICollection<ContactMessage> ContactMessages { get; set; } = [];
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();

    }
}
