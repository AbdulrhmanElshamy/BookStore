namespace BookShoppingCartMVC.ViewModels.OutComing
{
    public class HomeVM
    {
        public IEnumerable<BookVM> Books { get; set; }

        public IEnumerable<GenreVM> Genres { get; set; }

    }
}
