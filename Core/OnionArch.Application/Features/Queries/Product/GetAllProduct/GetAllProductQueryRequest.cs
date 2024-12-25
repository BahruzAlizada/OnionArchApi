

using MediatR;
using OnionArch.Application.Parametres.RequestParametres;

namespace OnionArch.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryRequest : IRequest<GetAllProductQueryResponse>
    {
        public Pagination Pagination { get; set; }
    }
}
