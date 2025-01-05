

using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Constant;
using OnionArch.Domain.Identity;

namespace OnionArch.Application.Features.Commands.Role.DeleteRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommandRequest, DeleteRoleCommandResponse>
    {
        private readonly RoleManager<AppRole> roleManager;
        public DeleteRoleCommandHandler(RoleManager<AppRole> roleManager)
        {
            this.roleManager = roleManager;
        }


        public async Task<DeleteRoleCommandResponse> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
        {
            AppRole? role = await roleManager.Roles.FirstOrDefaultAsync(x=>x.Id==request.Id);
            if (role == null)
            {
                return new DeleteRoleCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = Messages.IdNull
                    }
                };
            }

            await roleManager.DeleteAsync(role);
            return new DeleteRoleCommandResponse
            {
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessDeleted
                }
            };
        }
    }
}
