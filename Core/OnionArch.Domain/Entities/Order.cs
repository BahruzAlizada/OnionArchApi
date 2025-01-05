
using OnionArch.Domain.Common;

namespace OnionArch.Domain.Entities
{
    public class Order : EntityList
    {
        public Guid BasketId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        public string OrderCode { get; set; }

        public Basket Basket { get; set; }
        public CompletedOrder CompletedOrder { get; set; }
    }
}
