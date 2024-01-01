using System.ComponentModel.DataAnnotations;

namespace BookShoppingCartMVC.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public virtual ICollection<Book> Books { get; set;}
    
    }
}
