
using OnionArch.Domain.Common;

namespace OnionArch.Domain.Entities
{
    public class Order : EntityList
    {
        public Guid CustomerId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public ICollection<Product> Products { get; set; }
        public Customer Customer { get; set; }
    }
}
