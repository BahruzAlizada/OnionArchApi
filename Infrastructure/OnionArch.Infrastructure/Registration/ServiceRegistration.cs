
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OnionArch.Application.Abstractions;
using OnionArch.Application.Configurations;
using OnionArch.Infrastructure.Services.Configuration;

namespace OnionArch.Infrastructure.Registration
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, OnionArch.Infrastructure.Services.TokenHandler>();
            services.AddScoped<IApplicationService,ApplicationService>();
        }
    }
}
