namespace BookShoppingCartMVC.ViewModels.OutComing
{
    public class ShoppingCartVM
    {
        public int Id { get; set; }

        public IEnumerable<CartDetailVM> CartDetailsVM { get; set; }
    }
}
