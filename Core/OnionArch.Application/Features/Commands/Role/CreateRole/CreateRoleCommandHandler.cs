

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Constant;
using OnionArch.Application.Extensions.FluentValidationExtension;
using OnionArch.Application.Rule;
using OnionArch.Application.Rule.Abstract;
using OnionArch.Application.Validation.FluentValidation.RoleValidator;
using OnionArch.Domain.Identity;

namespace OnionArch.Application.Features.Commands.Role.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, CreateRoleCommandResponse>
    {
        private readonly RoleManager<AppRole> roleManager;
        private readonly IRoleRule roleRule;
        private readonly IMapper mapper;
        public CreateRoleCommandHandler(RoleManager<AppRole> roleManager,IRoleRule roleRule, IMapper mapper)
        {
            this.roleManager = roleManager;
            this.roleRule = roleRule;
            this.mapper = mapper;
        }


        public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await new RoleAddValidator().ValidateAsync(request.RoleAddDto);
            if (!validationResult.IsValid)
            {
                return new CreateRoleCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = validationResult.ValidationErrorString()
                    }
                };
            }

            var result = BusinessRules.Run(roleRule.CheckIfNameExisted(request.RoleAddDto.Name));
            if(!result.Success)
            {
                return new CreateRoleCommandResponse { Result = result };
            }

            AppRole appRole = mapper.Map<AppRole>(request.RoleAddDto);

            await roleManager.CreateAsync(appRole);
            return new CreateRoleCommandResponse
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
