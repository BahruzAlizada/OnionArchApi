

namespace OnionArch.Domain.Common
{
    public class EntityList : BaseEntity
    {
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow.AddHours(4);
        virtual public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; } = true;
    }
}
