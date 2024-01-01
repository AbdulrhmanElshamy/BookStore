using Microsoft.AspNetCore.Identity;

namespace BookShoppingCartMVC.Models
{
    public class AppUser : IdentityUser
    {

        public virtual ICollection<Order> Orders { get; set; }
    }
}
