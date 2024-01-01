using BookShoppingCartMVC.ViewModels.OutComing;

namespace BookShoppingCartMVC.Repositories.CardRepos
{
    public interface ICartRepository
    {
        Task<int> AddItem(int bookId, int quntity, string userId);

        Task<int> RemoveItem(int bookId, string userId);

        Task<ShoppingCartVM> GetUserCart(string userId);

        Task<int> GetCartItemsCount(string userId);
    }
}
