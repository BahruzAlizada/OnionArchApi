
using OnionArch.Application.DTOs;
using OnionArch.Application.Parametres.ResponseParametres;

namespace OnionArch.Application.Features.Queries.User.GetAllUser
{
    public class GetAllUserQueryResponse
    {
        public List<UserDto> Users { get; set; }
        public Result Result { get; set; }
    }
}
