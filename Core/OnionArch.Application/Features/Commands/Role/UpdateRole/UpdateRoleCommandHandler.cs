using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using OnionArch.Application.Constant;
using OnionArch.Application.Extensions.FluentValidationExtension;
using OnionArch.Application.Rule;
using OnionArch.Application.Rule.Abstract;
using OnionArch.Application.Validation.FluentValidation.RoleValidator;
using OnionArch.Domain.Identity;

namespace OnionArch.Application.Features.Commands.Role.UpdateRole
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommandRequest, UpdateRoleCommandResponse>
    {
        private readonly RoleManager<AppRole> roleManager;
        private readonly IRoleRule roleRule;
        private readonly IMapper mapper;
        public UpdateRoleCommandHandler(RoleManager<AppRole> roleManager, IRoleRule roleRule, IMapper mapper)
        {
            this.roleManager = roleManager;
            this.roleRule = roleRule;
            this.mapper = mapper;
        }


        public async Task<UpdateRoleCommandResponse> Handle(UpdateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await new RoleUpdateValidator().ValidateAsync(request.roleUpdateDto);
            if (!validationResult.IsValid)
            {
                return new UpdateRoleCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = validationResult.ValidationErrorString()
                    }
                };
            }

            var result = BusinessRules.Run(roleRule.CheckIfNameExisted(request.roleUpdateDto.Name, request.roleUpdateDto.Id));
            if (!result.Success)
            {
                return new UpdateRoleCommandResponse { Result = result };
            }


            var existingRole = await roleManager.FindByIdAsync(request.roleUpdateDto.Id.ToString());
            if (existingRole == null)
            {
                return new UpdateRoleCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = Messages.IdNull
                    }
                };
            }

            // Mövcud rolu yeniləyin
            mapper.Map(request.roleUpdateDto, existingRole); // Mövcud obyektin üzərində dəyişiklik

            await roleManager.UpdateAsync(existingRole);

            return new UpdateRoleCommandResponse
            {
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessUpdated
                }
            };
        }
    }
}
