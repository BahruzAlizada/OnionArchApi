
using Microsoft.Extensions.DependencyInjection;
using OnionArch.Application.Abstractions;
using OnionArch.Persistence.Concrete;
using OnionArch.Persistence.Context;

namespace OnionArch.Persistence.Registration
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

        }
    }
}
