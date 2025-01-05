
using MediatR;
using OnionArch.Application.DTOs;

namespace OnionArch.Application.Features.Commands.User.LoginUser
{
    public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
    {
        public UserLoginDto userLoginDto {  get; set; }
    }
}
