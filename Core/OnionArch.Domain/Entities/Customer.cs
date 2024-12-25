

using OnionArch.Domain.Common;

namespace OnionArch.Domain.Entities
{
    public class Customer : EntityList
    {
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
