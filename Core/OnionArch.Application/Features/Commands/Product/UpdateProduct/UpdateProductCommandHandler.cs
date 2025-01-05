using AutoMapper;
using MediatR;
using OnionArch.Application.Abstractions;
using OnionArch.Application.Constant;
using OnionArch.Application.Extensions.FluentValidationExtension;
using OnionArch.Application.Rule;
using OnionArch.Application.Rule.Abstract;
using OnionArch.Application.Validation.FluentValidation.ProductValidator;

namespace OnionArch.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductWriteRepository productWriteRepository;
        private readonly IProductRule productRule;
        private readonly IMapper mapper;
        public UpdateProductCommandHandler(IProductWriteRepository productWriteRepository, IProductRule productRule, IMapper mapper)
        {
            this.productWriteRepository = productWriteRepository;
            this.productRule = productRule;
            this.mapper = mapper;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await new ProductUpdateValidator().ValidateAsync(request.ProductUpdateDto);
            if (!validationResult.IsValid)
                return new UpdateProductCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result { Success = false, Message = validationResult.ValidationErrorString() }
                };

            var result = BusinessRules.Run(productRule.CheckIfNameExisted(request.ProductUpdateDto.Name, request.ProductUpdateDto.Id));
            if (!result.Success)
            {
                return new UpdateProductCommandResponse { Result = result };
            }

            var product = mapper.Map<Domain.Entities.Product>(request.ProductUpdateDto);
            product.UpdatedDate = DateTime.UtcNow.AddHours(4);

            productWriteRepository.Update(product);
            await productWriteRepository.SaveAsync();

            return new UpdateProductCommandResponse
            {
                Result = new Parametres.ResponseParametres.Result
                {
                    Message = Messages.SuccessUpdated,
                    Success = true,
                }
            };
        }
    }
}
