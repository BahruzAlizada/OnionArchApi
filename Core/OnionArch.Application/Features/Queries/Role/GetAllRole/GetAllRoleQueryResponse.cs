using OnionArch.Application.DTOs;
using OnionArch.Application.Parametres.ResponseParametres;

namespace OnionArch.Application.Features.Queries.Role.GetAllRole
{
    public class GetAllRoleQueryResponse
    {
        public List<RoleDto> Roles { get; set; }
        public Result Result { get; set; }
    }
}
