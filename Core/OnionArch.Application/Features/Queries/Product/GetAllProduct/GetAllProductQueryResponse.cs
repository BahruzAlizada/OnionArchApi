
using OnionArch.Application.Parametres.ResponseParametres;

namespace OnionArch.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryResponse
    {
        public int TotalCount { get; set; }
        public object Products { get; set; }
        public Result Result { get; set; }
    }
}
