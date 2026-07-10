namespace AqarPlatform.Domain.Entities
{
    public class PropertyFeature
    {
        public Guid PropertyId { get; set; }

        public Property Property { get; set; } = null!;

        public Guid FeatureId { get; set; }

        public PropertyFeature Feature { get; set; } = null!;
    }
}
