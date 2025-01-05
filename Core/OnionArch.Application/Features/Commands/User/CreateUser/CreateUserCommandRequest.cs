using MediatR;
using OnionArch.Application.DTOs;

namespace OnionArch.Application.Features.Commands.User.CreateUser
{
    public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
    {
        public UserAddDto UserAddDto { get; set; }
    }
}
