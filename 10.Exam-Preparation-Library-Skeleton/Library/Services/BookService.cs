using Library.Contracts;
using Library.Data;
using Library.Data.Models;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext _context;

        public BookService(LibraryDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task AddBookToCollectionAsync(string userId, BookViewModel book)
        {
            bool alreadyAdded = await _context.IdentityUserBooks
                .AnyAsync(ub => ub.CollectorId == userId && ub.BookId == book.Id);

            if (!alreadyAdded)
            {
                IdentityUserBook userBook = new IdentityUserBook()
                {
                    CollectorId = userId,
                    BookId = book.Id
                };

                await _context.IdentityUserBooks.AddAsync(userBook);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync()
        {
            return await this._context
                .Books
                .Select(b => new AllBookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Category = b.Category.Name
                }).ToListAsync();
        }

        public async Task<BookViewModel?> GetBookByIdAsync(int id)
        {
            return await _context
                .Books
                .Where(b => b.Id == id)
                .Select(b => new BookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Description = b.Description,
                    CategoryId = b.CategoryId
                }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AllBookViewModel>> GetMyBooksAsync(string userId)
        {
            return await _context.IdentityUserBooks
                .Where(ub => ub.CollectorId == userId)
                .Select(b => new AllBookViewModel
                {
                    Id = b.Book.Id,
                    Title = b.Book.Title,
                    Author = b.Book.Author,
                    ImageUrl = b.Book.ImageUrl,
                    Description = b.Book.Description,
                    Category = b.Book.Category.Name
                }).ToListAsync();
        }

        

        public async Task RemoveBookByIdAsync(string userId, BookViewModel book)
        {
            var bookToRemove = _context.IdentityUserBooks
                .FirstOrDefault(ub => ub.CollectorId == userId && ub.BookId == book.Id);

            _context.IdentityUserBooks.Remove(bookToRemove);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<CategoryViewModel>> GetCategories()
        {
            var categories = await _context.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToArrayAsync();


            return categories;
        }

        public async Task AddBooksPost(AddPostBookViewModel bookViewModel)
        {
            Book book = new Book()
            {
                Title = bookViewModel.Title,
                Author = bookViewModel.Author,
                ImageUrl = bookViewModel.Url,
                Description = bookViewModel.Description,
                Rating = bookViewModel.Rating,
                CategoryId = bookViewModel.CategoryId
            };

            await _context.AddAsync(book);
            await _context.SaveChangesAsync();
        }
    }
}