using OnionArch.Application.DTOs;

namespace OnionArch.Application.Configurations
{
    public interface IApplicationService
    {
        List<Menu> GetAuthorizeDefinitionEndpoints(Type type);
    }
}
