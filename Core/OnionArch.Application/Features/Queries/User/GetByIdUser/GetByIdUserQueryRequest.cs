using MediatR;

namespace OnionArch.Application.Features.Queries.User.GetByIdUser
{
    public class GetByIdUserQueryRequest : IRequest<GetByIdUserQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
