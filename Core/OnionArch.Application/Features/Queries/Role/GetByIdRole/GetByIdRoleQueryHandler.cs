using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Constant;
using OnionArch.Application.DTOs;
using OnionArch.Domain.Identity;

namespace OnionArch.Application.Features.Queries.Role.GetByIdRole
{
    public class GetByIdRoleQueryHandler : IRequestHandler<GetByIdRoleQueryRequest, GetByIdRoleQueryResponse>
    {
        private readonly RoleManager<AppRole> roleManager;
        private readonly IMapper mapper;
        public GetByIdRoleQueryHandler(RoleManager<AppRole> roleManager, IMapper mapper)
        {
            this.roleManager = roleManager;
            this.mapper = mapper;
        }


        public async Task<GetByIdRoleQueryResponse> Handle(GetByIdRoleQueryRequest request, CancellationToken cancellationToken)
        {
            AppRole? appRole = await roleManager.Roles.FirstOrDefaultAsync(x=>x.Id == request.Id);
            if (appRole == null)
            {
                return new GetByIdRoleQueryResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = Messages.IdNull
                    }
                };
            }

            RoleDto role = mapper.Map<RoleDto>(appRole);

            return new GetByIdRoleQueryResponse
            {
                RoleDto = role,
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessGetFiltered
                }
            };

        }
    }
}
