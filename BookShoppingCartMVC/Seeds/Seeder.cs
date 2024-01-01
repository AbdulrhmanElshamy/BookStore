using BookShoppingCartMVC.Constants;
using BookShoppingCartMVC.Models;
using Microsoft.AspNetCore.Identity;

namespace BookShoppingCartMVC.Seeds
{
    public class Seeder
    {
        public static async Task SeedDefualtData(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetService<UserManager<AppUser>>();
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));


            var admin = new AppUser()
            {
                UserName = "admin@gmail.com",
                Email = "admin.gmail.com",
                EmailConfirmed = true,

            };

            var isUserExist = await userManager.FindByEmailAsync(admin.Email);

            if (isUserExist is null)
            {
                await userManager.CreateAsync(admin,"P@ssword123");

                await userManager.AddToRoleAsync(admin, Roles.Admin.ToString());
                
            }
            
        }
    }
}
