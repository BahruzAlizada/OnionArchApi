

using OnionArch.Domain.Common;

namespace OnionArch.Domain.Entities
{
    public class Product : EntityList
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
