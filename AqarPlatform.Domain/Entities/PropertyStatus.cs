using AqarPlatform.Domain.Common;

namespace AqarPlatform.Domain.Entities
{
    public class PropertyStatus : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<Property> Properties { get; set; } = [];
    }
}
