using Microsoft.AspNetCore.Identity;

namespace AqarPlatform.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;

        public string? ProfileImage { get; set; }

        public ICollection<Property> Properties { get; set; } = [];
        public ICollection<Favorite> Favorites { get; set; } = [];
        public ICollection<Review> Reviews { get; set; }    =new HashSet<Review>();
    }
}
