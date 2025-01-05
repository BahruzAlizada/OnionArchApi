using OnionArch.Application.DTOs;
using OnionArch.Application.Parametres.ResponseParametres;

namespace OnionArch.Application.Features.Commands.User.LoginUser
{
    public class LoginUserCommandResponse
    {
        public Result Result { get; set; }
        public Token? Token { get; set; }
    }
}
