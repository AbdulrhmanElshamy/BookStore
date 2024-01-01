using BookShoppingCartMVC.Data;
using BookShoppingCartMVC.Models;
using BookShoppingCartMVC.ViewModels.OutComing;
using Microsoft.EntityFrameworkCore;

namespace BookShoppingCartMVC.Repositories.HomeRepos
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<BookVM>> DisplayBooks(string searchTerm = "", int GenreId = 0)
        {
            var query = _dbContext.Books.AsQueryable();

            var books = await query
                .Where(b => (string.IsNullOrWhiteSpace(searchTerm) || b.Name.ToLower().Contains(searchTerm.ToLower())) 
                && (GenreId == 0 || b.GenreId == GenreId))
                .Select(b => new BookVM
                {
                    Id = b.Id,
                    Name = b.Name,
                    Image = b.Image,
                    Genre = b.Genre.Name,
                    AuthorName = b.AuthorName,
                    Price = b.Price,
                })
                .AsNoTracking()
                .ToListAsync();

            return books;
        }

        public async Task<IEnumerable<GenreVM>> DispalyGenres()
        {
            IEnumerable<GenreVM> genres = await _dbContext.Genres
                .Select(g => new GenreVM()
                {
                    Id = g.Id,
                    Name = g.Name,
                })
                .OrderBy(g => g.Name)
                .AsNoTracking()
                .ToListAsync();

            return genres;
        }


    }
}
