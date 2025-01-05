

using OnionArch.Application.DTOs;
using OnionArch.Application.Parametres.ResponseParametres;

namespace OnionArch.Application.Features.Queries.Product.GetByIdProduct
{
    public class GetByIdProductQueryResponse
    {
        public Result Result { get; set; }
        public ProductDto? ProductDto { get; set; }
    }
}
