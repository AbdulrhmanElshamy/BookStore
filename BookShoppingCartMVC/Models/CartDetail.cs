using System.ComponentModel.DataAnnotations;

namespace BookShoppingCartMVC.Models
{
    public class CartDetail
    {
        public int Id { get; set; }

        [Required]
        public int ShoppingCartId { get; set; }

        [Required]
        public int BookId { get; set; }
        
        public int Quantity { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }

        public virtual Book Book { get; set; }

    }
}
