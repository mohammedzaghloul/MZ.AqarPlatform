using AqarPlatform.Domain.Common;

namespace AqarPlatform.Domain.Entities
{
    public class PropertyImage : BaseEntity
    {
        public string ImageUrl { get; set; } = string.Empty;

        public bool IsMain { get; set; }

        public Guid PropertyId { get; set; }

        public Property Property { get; set; } = null!;
    }
}
