using AqarPlatform.Domain.Common;

namespace AqarPlatform.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }

        public ICollection<Property> Properties { get; set; } = [];
    }
}
