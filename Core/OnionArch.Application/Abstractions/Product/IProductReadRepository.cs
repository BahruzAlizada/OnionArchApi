using OnionArch.Application.Repositories;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Abstractions
{
    public interface IProductReadRepository : IReadRepository<Product>
    {
    }
}
