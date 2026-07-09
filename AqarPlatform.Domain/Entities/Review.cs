using AqarPlatform.Domain.Common;

namespace AqarPlatform.Domain.Entities
{
    public class Review : BaseEntity
    {
        public int Rating { get; set; }

        public string Comment { get; set; } = string.Empty;

        public Guid PropertyId { get; set; }

        public Property Property { get; set; } = null!;

        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; } = null!;
    }
}
