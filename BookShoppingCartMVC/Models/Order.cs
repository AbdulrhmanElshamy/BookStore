using System.ComponentModel.DataAnnotations;

namespace BookShoppingCartMVC.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        public int OrderStatusId { get; set; }

        public bool IsDeleted { get; set; }


        public virtual AppUser AppUser { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }

    }
}
