using System.ComponentModel.DataAnnotations;

namespace BookShoppingCartMVC.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }


        public bool IsDeleted { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual AppUser User { get; set; }

        public virtual ICollection<CartDetail> CartDetails { get; set; }

    }
}
