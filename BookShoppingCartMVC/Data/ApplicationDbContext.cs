﻿using BookShoppingCartMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookShoppingCartMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<CartDetail> CartDetails { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Order> Orders { get; set; }    

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set;}
    }
}