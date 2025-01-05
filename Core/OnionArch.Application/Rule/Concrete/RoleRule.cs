

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Abstractions;
using OnionArch.Application.Constant;
using OnionArch.Application.Parametres.ResponseParametres;
using OnionArch.Application.Rule.Abstract;
using OnionArch.Domain.Identity;

namespace OnionArch.Application.Rule.Concrete
{
    public class RoleRule : IRoleRule
    {
        private readonly RoleManager<AppRole> roleManager;
        public RoleRule(RoleManager<AppRole> roleManager)
        {
            this.roleManager = roleManager;
        }


        public Result CheckIfNameExisted(string name, Guid? id = null)
        {
            if (id.HasValue)
            {
                var roleExist = roleManager.Roles.ToList().Any(x => x.Name == name && x.Id != id.Value);

                if (roleExist)
                {
                    return new Result { Success = false, Message = Messages.CheckIfNameExisted };
                }
            }
            else
            {
                var roleExist = roleManager.Roles.ToList().Any(x => x.Name == name);

                if (roleExist)
                {
                    return new Result { Success = false, Message = Messages.CheckIfNameExisted };
                }
            }

            return new Result { Success = true };
        }
    }
}
