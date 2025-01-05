

using MediatR;

namespace OnionArch.Application.Features.Queries.Role.GetByIdRole
{
    public class GetByIdRoleQueryRequest : IRequest<GetByIdRoleQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
