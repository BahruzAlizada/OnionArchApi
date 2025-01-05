
using OnionArch.Application.DTOs;
using OnionArch.Application.Parametres.ResponseParametres;

namespace OnionArch.Application.Features.Queries.Role.GetByIdRole
{
    public class GetByIdRoleQueryResponse
    {
        public RoleDto? RoleDto { get; set; }
        public Result Result { get; set; }
    }
}
