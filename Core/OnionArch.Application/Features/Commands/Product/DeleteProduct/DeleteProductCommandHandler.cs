

using AutoMapper;
using MediatR;
using OnionArch.Application.Abstractions;
using OnionArch.Application.Constant;

namespace OnionArch.Application.Features.Commands.Product.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IProductReadRepository productReadRepository;
        private readonly IProductWriteRepository productWriteRepository;
        public DeleteProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            this.productReadRepository = productReadRepository;
            this.productWriteRepository = productWriteRepository;
        }
        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            OnionArch.Domain.Entities.Product? product = await productReadRepository.GetSingleAsync(x=>x.Id == request.Id);
            if(product is null)
            {
                return new DeleteProductCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = Messages.IdNull
                    }
                };
            }

            productWriteRepository.Remove(product);
            await productWriteRepository.SaveAsync();

            return new DeleteProductCommandResponse
            {
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessDeleted
                }
            };
        }
    }
}
