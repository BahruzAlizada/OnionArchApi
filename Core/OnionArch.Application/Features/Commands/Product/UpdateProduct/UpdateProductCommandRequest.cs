using MediatR;
using OnionArch.Application.DTOs;

namespace OnionArch.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandRequest : IRequest<UpdateProductCommandResponse>
    {
        public ProductUpdateDto ProductUpdateDto { get; set; }
    }
}
