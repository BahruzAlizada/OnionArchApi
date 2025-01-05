using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using OnionArch.Application.Constant;
using OnionArch.Application.DTOs;
using OnionArch.Application.Exceptions;
using OnionArch.Domain.Identity;

namespace OnionArch.Application.Features.Queries.User.GetByIdUser
{
    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQueryRequest, GetByIdUserQueryResponse>
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;
        public GetByIdUserQueryHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public async Task<GetByIdUserQueryResponse> Handle(GetByIdUserQueryRequest request, CancellationToken cancellationToken)
        {
            AppUser? user = await userManager.FindByIdAsync(request.Id.ToString());
            if (user is null)
            {
                throw new UserNotFoundException();
            }

            UserDto userDto = mapper.Map<UserDto>(user);

            return new GetByIdUserQueryResponse
            {
                UserDto = userDto,
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessGetFiltered
                }
            };
        }
    }
}
