using OnionArch.Application.Abstractions;
using OnionArch.Domain.Entities;
using OnionArch.Persistence.Context;
using OnionArch.Persistence.Repositories;

namespace OnionArch.Persistence.Concrete
{
    public class BasketItemWriteRepository : WriteRepository<BasketItem>, IBasketItemWriteRepository
    {
        public BasketItemWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
