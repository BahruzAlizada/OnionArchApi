

using AutoMapper;
using MediatR;
using OnionArch.Application.Abstractions;
using OnionArch.Application.Constant;
using OnionArch.Application.DTOs;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Features.Queries.Product.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        private readonly IProductReadRepository productReadRepository;
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        public GetByIdProductQueryHandler(IProductReadRepository productReadRepository, IMediator mediator, IMapper mapper)
        {
            this.productReadRepository = productReadRepository;
            this.mediator = mediator;
            this.mapper = mapper;
        }

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            OnionArch.Domain.Entities.Product? product = await productReadRepository.GetSingleAsync(x=>x.Id==request.Id);
            if(product is null)
            {
                return new GetByIdProductQueryResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Message = Messages.IdNull,
                        Success = false
                    }
                };
            }

            ProductDto productDto = mapper.Map<ProductDto>(product);

            return new GetByIdProductQueryResponse
            {
                ProductDto = productDto,
                Result = new Parametres.ResponseParametres.Result
                {
                    Message = Messages.SuccessGetFiltered,
                    Success = true
                }
            };

        }
    }
}
