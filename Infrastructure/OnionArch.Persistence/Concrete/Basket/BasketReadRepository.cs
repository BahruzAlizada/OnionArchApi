using OnionArch.Application.Abstractions;
using OnionArch.Domain.Entities;
using OnionArch.Persistence.Context;
using OnionArch.Persistence.Repositories;

namespace OnionArch.Persistence.Concrete
{
    public class BasketReadRepository : ReadRepository<Basket>, IBasketReadRepository
    {
        public BasketReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
