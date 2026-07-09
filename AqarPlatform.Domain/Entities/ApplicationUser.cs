using Microsoft.AspNetCore.Identity;

namespace AqarPlatform.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FullName { get; set; } = string.Empty;

        public string? ProfileImage { get; set; }

        public ICollection<Property> Properties { get; set; } = [];
    }
}
