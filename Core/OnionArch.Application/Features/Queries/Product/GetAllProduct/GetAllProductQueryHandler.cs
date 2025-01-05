using AutoMapper;
using MediatR;
using OnionArch.Application;
using OnionArch.Application.Abstractions;
using OnionArch.Application.Constant;
using OnionArch.Application.DTOs;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        private readonly IProductReadRepository productReadRepository;
        private readonly IMapper mapper;
        public GetAllProductQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
        {
            this.productReadRepository = productReadRepository;
            this.mapper = mapper;
        }

        public Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount = productReadRepository.GetAll(false).Count();
            var products = productReadRepository.GetAll(false).Skip(request.Pagination.Page * request.Pagination.Size).Take(request.Pagination.Size).ToList();

            var productsDto = mapper.Map<List<ProductDto>>(products);

            var response = new GetAllProductQueryResponse
            {
                TotalCount = totalCount,
                ProductDtos = productsDto,
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
