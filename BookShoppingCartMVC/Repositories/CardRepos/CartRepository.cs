using BookShoppingCartMVC.Data;
using BookShoppingCartMVC.Models;
using BookShoppingCartMVC.ViewModels.OutComing;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BookShoppingCartMVC.Repositories.CardRepos
{
    public partial class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CartRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddItem(int bookId, int quntity, string userId)
        {
            try
            {
                using var transaction = _dbContext.Database.BeginTransaction();

                var cart = await GetCart(userId);

                if (cart is null)
                {
                    cart = new ShoppingCart()
                    {
                        UserId = userId
                    };
                    await _dbContext.AddAsync(cart);
                    await _dbContext.SaveChangesAsync();
                }

                var CartItem = await _dbContext.CartDetails.FirstOrDefaultAsync(s => s.ShoppingCartId == cart.Id && s.BookId == bookId);

                if (CartItem is not null)
                {
                    CartItem.Quantity += quntity;

                }
                else
                {
                    CartItem = new CartDetail()
                    {
                        BookId = bookId,
                        ShoppingCartId = cart.Id,
                        Quantity = quntity
                    };

                    await _dbContext.AddAsync(CartItem);
                }
                await _dbContext.SaveChangesAsync();

                transaction.Commit();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return await GetCartItemsCount(userId);


        }


        public async Task<int> RemoveItem(int bookId, string userId)
        {
            try
            {
                var cart = await GetCart(userId);

                if (cart is null)
                {
                    throw new Exception("invaild opration");

                }

                var CartItem = await _dbContext.CartDetails.FirstOrDefaultAsync(s => s.ShoppingCartId == cart.Id && s.BookId == bookId);

                if (CartItem is null)
                {
                    throw new Exception("invaild opration");


                }
                else if (CartItem.Quantity == 1)
                {
                    _dbContext.ShoppingCarts.Remove(cart);
                }
                else
                {
                    CartItem.Quantity--;
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

            return await GetCartItemsCount(userId);


        }


        public async Task<ShoppingCartVM> GetUserCart(string userId)
        {
            var ShoppingCart = await _dbContext.ShoppingCarts
                .Select(s => new ShoppingCartVM()
                {
                    Id = s.Id,
                    CartDetailsVM = s.CartDetails.Select(c => new CartDetailVM()
                    {
                        BookName = c.Book.Name,
                        Price = c.Book.Price,
                        Quntity = c.Quantity
                    }).ToList(),
                })
                .FirstOrDefaultAsync();

            return ShoppingCart;
        }


        public async Task<int> GetCartItemsCount(string UserId)
        {

            if(string.IsNullOrEmpty(UserId))
                return 0;

            var count = _dbContext.ShoppingCarts
                      .Where(x => x.UserId == UserId)
                      .Join(_dbContext.CartDetails,
                       cart => cart.Id,
                       cartDetail => cartDetail.ShoppingCartId, 
                      (cart, cartDetail) => new { cart, cartDetail })
                     .Count();


            return count;
        }


        private async Task<ShoppingCart> GetCart(string UserId)
        {
            var cart = await _dbContext.ShoppingCarts.FirstOrDefaultAsync(s => s.UserId == UserId);

            return cart;
        }
    }
}
