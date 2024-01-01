using BookShoppingCartMVC.Repositories.CardRepos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShoppingCartMVC.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }


        public async Task<IActionResult> Index()
        {
            var cart = _cartRepository.GetUserCart(User.GetUserId());

            return View(cart);

        }

        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public async Task<IActionResult> AddItem(int bookId)
        {
            var res = await _cartRepository.AddItem(bookId, 1,User.GetUserId());

            return Ok(res);

        }



        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public async Task<IActionResult> RemoveItem(int bookId)
        {
            var res = await _cartRepository.RemoveItem(bookId,User.GetUserId());

            return Ok(res);

        }


        [HttpGet]
        public async Task<IActionResult> GetUserCart()
        {
            var cart = await _cartRepository.GetUserCart(User.GetUserId());

            return View(cart);
        }


        [HttpGet]
        public async Task<IActionResult> GetCartItems()
        {
            
            var count = await _cartRepository.GetCartItemsCount(User.GetUserId());

            return Ok(count);
        }


    }
}
