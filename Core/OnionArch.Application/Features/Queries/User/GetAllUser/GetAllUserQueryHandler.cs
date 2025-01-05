

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Constant;
using OnionArch.Application.DTOs;
using OnionArch.Domain.Identity;

namespace OnionArch.Application.Features.Queries.User.GetAllUser
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, GetAllUserQueryResponse>
    {

        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;
        public GetAllUserQueryHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;   
        }
        public async Task<GetAllUserQueryResponse> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            List<AppUser> users = await userManager.Users.ToListAsync();
            List<UserDto> userDtos = mapper.Map<List<UserDto>>(users);

            return new GetAllUserQueryResponse
            {
                Users = userDtos,
                Result = new Parametres.ResponseParametres.Result
                {
                    Message = Messages.SuccessListed,
                    Success = true,
                }
            };
        }
    }
}
