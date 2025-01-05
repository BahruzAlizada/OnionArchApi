using OnionArch.Domain.Common;

namespace OnionArch.Domain.Entities
{
    public class CompletedOrder : EntityList
    {
        public Guid OrderId { get; set; }
        public string Order {  get; set; }
    }
}
