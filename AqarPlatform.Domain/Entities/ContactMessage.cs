using AqarPlatform.Domain.Common;

namespace AqarPlatform.Domain.Entities
{
    public class ContactMessage : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public Guid PropertyId { get; set; }

        public Property Property { get; set; } = null!;
    }
}
