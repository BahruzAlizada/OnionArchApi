

namespace OnionArch.Application.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        virtual public DateTime UpdatedDate { get; set; }
    }
}
