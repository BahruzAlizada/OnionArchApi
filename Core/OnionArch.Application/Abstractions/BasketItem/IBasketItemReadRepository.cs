
using OnionArch.Application.Repositories;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Abstractions
{
    public interface IBasketItemReadRepository : IReadRepository<BasketItem>
    {
        Task<List<BasketItem>> GetBasketItems();
    }
}
