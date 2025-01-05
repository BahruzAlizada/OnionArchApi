using OnionArch.Application.DTOs;
using OnionArch.Application.Parametres.ResponseParametres;

namespace OnionArch.Application.Features.Queries.User.GetByIdUser
{
    public class GetByIdUserQueryResponse
    {
        public UserDto UserDto { get; set; }
        public Result Result { get; set; }
    }
}
