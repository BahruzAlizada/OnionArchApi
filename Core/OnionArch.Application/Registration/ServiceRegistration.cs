using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnionArch.Application.Mappers.AutoMapper;
using OnionArch.Application.Rule.Abstract;
using OnionArch.Application.Rule.Concrete;

namespace OnionArch.Application.Registration
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistration));
            services.AddAutoMapper(typeof(DtoMapper));

            services.AddScoped<IProductRule,ProductRule>();
            services.AddScoped<IRoleRule, RoleRule>();
        }
    }
}
