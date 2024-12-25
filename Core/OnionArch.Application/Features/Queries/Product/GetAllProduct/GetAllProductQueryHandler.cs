using MediatR;
using OnionArch.Application;
using OnionArch.Application.Abstractions;
using OnionArch.Application.Constant;

namespace OnionArch.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        private readonly IProductReadRepository productReadRepository;
        public GetAllProductQueryHandler(IProductReadRepository productReadRepository)
        {
            this.productReadRepository = productReadRepository;
        }

        public Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount = productReadRepository.GetAll(false).Count();
            var products = productReadRepository.GetAll(false).Skip(request.Pagination.Page * request.Pagination.Size).Take(request.Pagination.Size).
                Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Price,
                    x.Stock,
                    x.CreatedDate,
                    x.UpdatedDate,
                    x.Status
                }).ToList();

            var response = new GetAllProductQueryResponse
            {
                TotalCount = totalCount,
                Products = products,
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessListed
                }
            };

            return Task.FromResult(response);
        }
    }
}
