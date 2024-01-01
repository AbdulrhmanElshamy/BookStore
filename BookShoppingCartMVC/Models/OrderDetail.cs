using System.ComponentModel.DataAnnotations;

namespace BookShoppingCartMVC.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        [Required]
        public int OrederId { get; set; }

        [Required]
        public int BookId { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [Required]
        public decimal Price { get; set; }

        public virtual Order Order { get; set; }

        public virtual Book Book { get; set; }
    }
}
