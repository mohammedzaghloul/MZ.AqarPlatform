using AqarPlatform.Domain.Common;

namespace AqarPlatform.Domain.Entities
{
    public class PropertyFeature : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<PropertyFeature> PropertyFeatures { get; set; } = [];
    }
}
