
using MediatR;

namespace OnionArch.Application.Features.Commands.Product.DeleteProduct
{
    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
