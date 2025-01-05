
using MediatR;
using OnionArch.Application.DTOs;

namespace OnionArch.Application.Features.Commands.User.UpdateUser
{
    public class UpdateUserCommandRequest : IRequest<UpdateUserCommandResponse>
    {
        public UserUpdateDto UserUpdateDto { get; set; }
    }
}
