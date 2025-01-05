using MediatR;
using Microsoft.AspNetCore.Identity;
using OnionArch.Application.Abstractions;
using OnionArch.Application.DTOs;
using OnionArch.Application.Exceptions;
using OnionArch.Application.Extensions.FluentValidationExtension;
using OnionArch.Application.Features.Commands.User.CreateUser;
using OnionArch.Application.Validation.FluentValidation.UserValidator;
using OnionArch.Domain.Identity;

namespace OnionArch.Application.Features.Commands.User.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ITokenHandler tokenHandler;
        private readonly IMediator mediator;
        public LoginUserCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IMediator mediator)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenHandler = tokenHandler;
            this.mediator = mediator;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await new UserLoginValidator().ValidateAsync(request.userLoginDto);
            if (!validationResult.IsValid)
                return new LoginUserCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    { Success = false, 
                    Message = validationResult.ValidationErrorString() }
                };

            AppUser? user = await userManager.FindByEmailAsync(request.userLoginDto.Email);
            if (user is null)
                throw new UserNotFoundException();

            var result = await signInManager.PasswordSignInAsync(user, request.userLoginDto.Password,true,true);
            if (!result.Succeeded)
            {
                return new LoginUserCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result { Message = "Failed", Success = false }
                };
            }

            Token token = tokenHandler.CreateAccessToken(5);
            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenEndDate = token.Expiration.AddMinutes(30);

            await userManager.UpdateAsync(user);

            return new LoginUserCommandResponse
            {
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = "Success Login",
                },
                Token = token
                
            };

        }
    }
}
