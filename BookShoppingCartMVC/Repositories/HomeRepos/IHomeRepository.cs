using BookShoppingCartMVC.ViewModels.OutComing;

namespace BookShoppingCartMVC.Repositories.HomeRepos
{
    public interface IHomeRepository
    {
        Task<IEnumerable<BookVM>> DisplayBooks(string searchTerm = "", int GenreId = 0);

        Task<IEnumerable<GenreVM>> DispalyGenres();
    }
}
