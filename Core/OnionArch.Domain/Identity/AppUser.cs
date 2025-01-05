using Microsoft.AspNetCore.Identity;
using OnionArch.Domain.Entities;

namespace OnionArch.Domain.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FullName { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }

        public ICollection<Basket> Baskets { get; set; }
    }
}
