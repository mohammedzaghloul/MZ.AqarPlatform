using AqarPlatform.Domain.Common;

namespace AqarPlatform.Domain.Entities
{
    public class Feature : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<PropertyFeature> PropertyFeatures { get; set; } = [];
    }
}
