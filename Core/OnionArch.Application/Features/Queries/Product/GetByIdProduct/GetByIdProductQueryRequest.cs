
using MediatR;

namespace OnionArch.Application.Features.Queries.Product.GetByIdProduct
{
    public class GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
