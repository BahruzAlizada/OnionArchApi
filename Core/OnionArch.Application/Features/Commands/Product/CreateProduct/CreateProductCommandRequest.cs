

using MediatR;
using OnionArch.Application.DTOs;

namespace OnionArch.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public ProductAddDto ProductAddDto { get; set; }
    }
}
