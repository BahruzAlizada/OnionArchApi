using MediatR;
using Microsoft.AspNetCore.Identity;
using OnionArch.Application.Constant;
using OnionArch.Application.Exceptions;
using OnionArch.Domain.Identity;

namespace OnionArch.Application.Features.Commands.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMediator mediator;
        public CreateUserCommandHandler(UserManager<AppUser> userManager,IMediator mediator)
        {
            this.userManager = userManager;
            this.mediator = mediator;
        }
        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser user = new AppUser
            {
                FullName = request.UserAddDto.FullName,
                UserName = request.UserAddDto.UserName,
                Email = request.UserAddDto.Email,
                
            };

            IdentityResult result = await userManager.CreateAsync(user,request.UserAddDto.Password);
            if (!result.Succeeded)
            {
                string errorMessages = string.Join("; ", result.Errors.Select(e => e.Description));
                return new CreateUserCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result { Message = errorMessages, Success = false }
                };
            }


            return new CreateUserCommandResponse
            {
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessAdded
                }
            };
        }
    }
}
