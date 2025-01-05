

using MediatR;
using OnionArch.Application.DTOs;

namespace OnionArch.Application.Features.Commands.Role.UpdateRole
{
    public class UpdateRoleCommandRequest : IRequest<UpdateRoleCommandResponse>
    {
        public RoleUpdateDto roleUpdateDto { get; set; }
    }
}
