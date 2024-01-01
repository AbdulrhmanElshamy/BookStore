using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BookShoppingCartMVC.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string AuthorName { get; set; }
        
        public string? Image { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int GenreId { get; set; }

        public virtual  Genre Genre { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }

        public virtual List<CartDetail> CartDetails { get; set; }

    }
}
