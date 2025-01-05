using OnionArch.Domain.Common;
using OnionArch.Domain.Identity;

namespace OnionArch.Domain.Entities
{
    public class Basket : EntityList
    {
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Order Order { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
