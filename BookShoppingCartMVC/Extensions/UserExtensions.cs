using System.Security.Claims;

namespace BookShoppingCartMVC.Repositories.CardRepos
{

        public static class UserExtensions
        {
            public static string GetUserId(this ClaimsPrincipal user) =>
                user.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        }
}
