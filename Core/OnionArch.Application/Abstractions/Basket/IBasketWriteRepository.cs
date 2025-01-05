using OnionArch.Application.DTOs;
using OnionArch.Application.Repositories;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Abstractions
{
    public interface IBasketWriteRepository : IWriteRepository<Basket>
    {
        Task AddItemToBasketAsync(BasketItemAddDto basketItemAddDto);
    }
}
