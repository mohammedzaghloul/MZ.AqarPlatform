using AqarPlatform.Domain.Common;

namespace AqarPlatform.Domain.Entities
{
    public class Favorite : BaseEntity
    {
        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; } = null!;

        public Guid PropertyId { get; set; }

        public Property Property { get; set; } = null!;
    }
}
