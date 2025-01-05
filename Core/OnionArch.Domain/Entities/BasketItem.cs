using OnionArch.Domain.Common;

namespace OnionArch.Domain.Entities
{
    public class BasketItem : EntityList
    {
        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public Basket Basket { get; set; }
        public Product Product { get; set; }
    }
}
