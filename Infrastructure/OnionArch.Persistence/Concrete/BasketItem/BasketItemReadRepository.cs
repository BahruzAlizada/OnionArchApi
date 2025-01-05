using OnionArch.Application.Abstractions;
using OnionArch.Domain.Entities;
using OnionArch.Persistence.Context;
using OnionArch.Persistence.Repositories;

namespace OnionArch.Persistence.Concrete
{
    public class BasketItemReadRepository : ReadRepository<BasketItem>, IBasketItemReadRepository
    {
        public BasketItemReadRepository(AppDbContext context) : base(context)
        {
        }

        public Task<List<BasketItem>> GetBasketItems()
        {
            throw new NotImplementedException();
        }
    }
}
