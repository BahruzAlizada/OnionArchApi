

using MediatR;
using Microsoft.AspNetCore.Identity;
using OnionArch.Application.Constant;
using OnionArch.Application.Exceptions;
using OnionArch.Application.Extensions.FluentValidationExtension;
using OnionArch.Application.Features.Commands.Product.CreateProduct;
using OnionArch.Application.Validation.FluentValidation.ProductValidator;
using OnionArch.Application.Validation.FluentValidation.UserValidator;
using OnionArch.Domain.Identity;

namespace OnionArch.Application.Features.Commands.User.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        private readonly UserManager<AppUser> userManager;
        public UpdateUserCommandHandler(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser? user = await userManager.FindByNameAsync(request.UserUpdateDto.UserName);
            if (user is null)
                throw new UserNotFoundException();

            var validationResult = await new UserUpdateValidator().ValidateAsync(request.UserUpdateDto);
            if (!validationResult.IsValid)
                return new UpdateUserCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Message = validationResult.ValidationErrorString(),
                        Success = false
                    }
                };

            user.FullName = request.UserUpdateDto.FullName;
            user.UserName = request.UserUpdateDto.UserName;
            user.Email = request.UserUpdateDto.Email;

            IdentityResult result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new UpdateUserCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Message = Messages.SuccessUpdated,
                        Success = true
                    }
                };
            }

            return new UpdateUserCommandResponse
            {
                Result = new Parametres.ResponseParametres.Result { Message = "Xeta", Success = false }
            };
        }
    }
}
