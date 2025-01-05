using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Abstractions;
using OnionArch.Application.DTOs;
using OnionArch.Domain.Entities;
using OnionArch.Domain.Identity;
using OnionArch.Persistence.Context;
using OnionArch.Persistence.Repositories;

namespace OnionArch.Persistence.Concrete
{
    public class BasketWriteRepository : WriteRepository<Basket>, IBasketWriteRepository
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<AppUser> userManager;
        private readonly AppDbContext context;
        public BasketWriteRepository(AppDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager) : base(context)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
        }

        public Task AddItemToBasketAsync(BasketItemAddDto basketItemAddDto)
        {
            throw new NotImplementedException();
        }

        //private async Task<Basket?> ContextUser()
        //{
        //    string userName = httpContextAccessor?.HttpContext?.User?.Identity?.Name;
        //    if (!string.IsNullOrEmpty(userName))
        //    {
        //        AppUser? appUser = await userManager.Users.Include(x=>x.Baskets).FirstOrDefaultAsync(x=>x.UserName == userName);
        //        if (appUser != null)
        //        {
        //            var targetBasket = appUser.Baskets.FirstOrDefault(b=>context.Orders.Any(o=>o.Id == b.Id));
        //            if (targetBasket == null)
        //            {
        //                targetBasket = new Basket();
        //                appUser.Baskets.Add(targetBasket);
        //                await context.SaveChangesAsync();
        //            }

        //            return targetBasket;
        //        }
        //        else
        //        {
        //            throw new Exception("An occur");
        //        }
        //    }
        //}

        //public async Task AddItemToBasketAsync(BasketItemAddDto basketItemAddDto)
        //{
        //    Basket? basket = await ContextUser();
        //    if(basket != null)
        //    {
        //        BasketItem basketItem = await context.BasketItems.FirstOrDefaultAsync(bi => bi.BasketId == basket.Id && bi.ProductId == basketItem.ProductId);
        //    }
        //}
    }
}
