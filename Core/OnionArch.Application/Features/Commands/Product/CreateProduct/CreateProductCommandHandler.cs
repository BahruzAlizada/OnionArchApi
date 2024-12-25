using AutoMapper;
using MediatR;
using OnionArch.Application.Abstractions;
using OnionArch.Application.Constant;
using OnionArch.Application.Extensions.FluentValidationExtension;
using OnionArch.Application.Rule;
using OnionArch.Application.Rule.Abstract;
using OnionArch.Application.Validation.FluentValidation;

namespace OnionArch.Application.Features.Commands.Product.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
{
    private readonly IProductWriteRepository productWriteRepository;
    private readonly IProductRule productRule;
    private readonly IMapper mapper;
    public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, IProductRule productRule, IMapper mapper)
    {
        this.productWriteRepository = productWriteRepository;
        this.productRule = productRule;
        this.mapper = mapper;
    }


    public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        #region Validation
        var validationResult = await new ProductAddValidator().ValidateAsync(request.ProductAddDto);
        if (!validationResult.IsValid)
            return new CreateProductCommandResponse
            {
                Result = new Parametres.ResponseParametres.Result
                {
                    Message = validationResult.ValidationErrorString(),
                    Success = false
                }
            };
        #endregion

        #region BusinessCode
        var result = BusinessRules.Run(productRule.CheckIfNameExisted(request.ProductAddDto.Name));
        if (!result.Success)
        {
            return new CreateProductCommandResponse { Result = result };
        };
        #endregion


        var product = mapper.Map<Domain.Entities.Product>(request.ProductAddDto); 
        
        await productWriteRepository.AddAsync(product);
        await productWriteRepository.SaveAsync();

        return new CreateProductCommandResponse
        {
            Result = new Parametres.ResponseParametres.Result
            {
                Success = true,
                Message = Messages.SuccessAdded
            }
        };
    }
  
}
