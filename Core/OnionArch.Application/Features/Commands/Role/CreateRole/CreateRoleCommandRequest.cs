using MediatR;
using OnionArch.Application.DTOs;

namespace OnionArch.Application.Features.Commands.Role.CreateRole
{
    public class CreateRoleCommandRequest : IRequest<CreateRoleCommandResponse>
    {
        public RoleAddDto RoleAddDto { get; set; }
    }
}
