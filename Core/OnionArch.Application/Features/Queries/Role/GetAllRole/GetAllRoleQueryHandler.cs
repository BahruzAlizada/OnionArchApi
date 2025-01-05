

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Constant;
using OnionArch.Application.DTOs;
using OnionArch.Domain.Identity;

namespace OnionArch.Application.Features.Queries.Role.GetAllRole
{
    public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQueryRequest, GetAllRoleQueryResponse>
    {
        private readonly RoleManager<AppRole> roleManager;
        private readonly IMapper mapper;
        public GetAllRoleQueryHandler(RoleManager<AppRole> roleManager, IMapper mapper)
        {
            this.roleManager = roleManager;
            this.mapper = mapper;
        }


        public async Task<GetAllRoleQueryResponse> Handle(GetAllRoleQueryRequest request, CancellationToken cancellationToken)
        {
            List<AppRole> roles = await roleManager.Roles.ToListAsync();
            List<RoleDto> roleDtos = mapper.Map<List<RoleDto>>(roles);

            return new GetAllRoleQueryResponse
            {
                Roles = roleDtos,
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessListed
                }
            };
        }
    }
}
