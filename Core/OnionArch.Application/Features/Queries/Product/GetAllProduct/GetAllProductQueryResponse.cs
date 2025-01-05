
using OnionArch.Application.DTOs;
using OnionArch.Application.Parametres.ResponseParametres;

namespace OnionArch.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryResponse
    {
        public int TotalCount { get; set; }
        public List<ProductDto> ProductDtos { get; set; }
        public Result Result { get; set; }
    }
}
