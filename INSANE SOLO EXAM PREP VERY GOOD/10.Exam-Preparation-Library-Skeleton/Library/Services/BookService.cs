using System.Globalization;
using Library.Data;
using Library.Data.Models;
using Library.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext _dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<ICollection<BookViewModel>> GetAllBooksAsync()
        {
            return await _dbContext.Books
                .Select(b => new BookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Category = b.Category.Name
                }).ToListAsync();
        }

        public async Task<ICollection<BookViewModel>> GetMyBooks(string userId)
        {
            return await _dbContext.IdentityUserBooks
                .Where(ub => ub.CollectorId == userId)
                .Select(ub => new BookViewModel
                {
                    Id = ub.Book.Id, //ub.BookId
                    ImageUrl = ub.Book.ImageUrl,
                    Title = ub.Book.Title,
                    Author = ub.Book.Author,
                    Description = ub.Book.Description,
                    Category = ub.Book.Category.Name
                }).ToListAsync();
        }

        public async Task<AddBookViewModel> GetNewAddBookViewModelAsync()
        {
            var categoriesViewModel = await _dbContext.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();

            var addBookViewModel = new AddBookViewModel
            {
                Categories = categoriesViewModel
            };

            return addBookViewModel;
        }

        public async Task AddBookAsync(AddBookViewModel addBookViewModel)
        {
            Book book = new Book
            {
                Title = addBookViewModel.Title,
                Author = addBookViewModel.Author,
                Description = addBookViewModel.Description,
                ImageUrl = addBookViewModel.Url,
                CategoryId = addBookViewModel.CategoryId,
                Rating = decimal.Parse(addBookViewModel.Rating)
            };

            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<BookViewModel?> GetBookByIdAsync(int bookId)
        {
            BookViewModel? book = await _dbContext.Books
                .Where(b => b.Id == bookId)
                .Select(b => new BookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Description = b.Description,
                    Rating = b.Rating,
                    CategoryId = b.CategoryId
                }).FirstOrDefaultAsync();

            return book;
        }

        public async Task AddBookToCollectionAsync(string userId, BookViewModel bookViewModel)
        {
            if (_dbContext.IdentityUserBooks.Any(ub => ub.CollectorId == userId && ub.BookId == bookViewModel.Id))
            {
                return;
            }

            IdentityUserBook identityUserBook = new IdentityUserBook
            {
                CollectorId = userId,
                BookId = bookViewModel.Id
            };

            await _dbContext.IdentityUserBooks.AddAsync(identityUserBook);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveBookFromCollectionAsync(string userId, BookViewModel bookViewModel)
        {
            var book = await _dbContext.IdentityUserBooks.FirstOrDefaultAsync(ub =>
                ub.CollectorId == userId && ub.BookId == bookViewModel.Id);

            if (book != null)
            {
                _dbContext.IdentityUserBooks.Remove(book);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<AddBookViewModel?> GetBookByIdForEditAsync(int bookId)
        {
            var categoriesViewModels = await _dbContext.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();

            AddBookViewModel? bookViewModel = await _dbContext
                .Books
                .Where(b => b.Id == bookId)
                .Select(b => new AddBookViewModel()
                {
                    Title = b.Title,
                    Author = b.Author,
                    Description = b.Description,
                    Url = b.ImageUrl,
                    Rating = b.Rating.ToString(),
                    CategoryId = b.CategoryId,
                    Categories = categoriesViewModels
                }).FirstOrDefaultAsync();

            return bookViewModel;
        }

        public async Task EditBookAsync(int bookId, AddBookViewModel bookViewModel)
        {
            Book? bookToEdit = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == bookId);

            if (bookToEdit != null)
            {
                bookToEdit.Title = bookViewModel.Title;
                bookToEdit.Author = bookViewModel.Author;
                bookToEdit.Description = bookViewModel.Description;
                bookToEdit.ImageUrl = bookViewModel.Url;
                bookToEdit.CategoryId = bookViewModel.CategoryId;
                bookToEdit.Rating = decimal.Parse(bookViewModel.Rating);

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteBookAsync(BookViewModel bookViewModel)
        {
            Book? bookToDelete = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == bookViewModel.Id);

            if (bookToDelete != null)
            {
                _dbContext.Books.Remove(bookToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}