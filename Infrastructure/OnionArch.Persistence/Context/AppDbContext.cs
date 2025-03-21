﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnionArch.Domain.Entities;
using OnionArch.Domain.Identity;

namespace OnionArch.Persistence.Context
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole,Guid>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-DQGN1O7;Database=OnionArch;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;Integrated Security=True;");
        }
         
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CompletedOrder> CompletedOrders { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
    }
}
