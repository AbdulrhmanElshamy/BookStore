using BookShoppingCartMVC.Data;
using BookShoppingCartMVC.Models;
using BookShoppingCartMVC.Repositories.HomeRepos;
using BookShoppingCartMVC.ViewModels.OutComing;
using Microsoft.AspNetCore.Mvc;

namespace BookShoppingCartMVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly IHomeRepository _homeRepository;

        public HomeController(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await _homeRepository.DisplayBooks("", 0);

            var genres = await _homeRepository.DispalyGenres();

            var DisplayHome = new HomeVM()
            {
                Books = books,
                Genres = genres,
            };

            return View(DisplayHome);
        }


        [HttpGet]
        public async Task<IActionResult> GetBooksByNameOrGenre(string searchTerm="",int GenreId = 0)
        {
            var books = await _homeRepository.DisplayBooks(searchTerm, GenreId);

            return PartialView("_bookPartial", books);
        
        }
    }
}
