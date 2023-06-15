using Library.ViewModels;

namespace Library.Services
{
    public interface IBookService
    {
        Task <ICollection<BookViewModel>> GetAllBooksAsync();

        Task<ICollection<BookViewModel>> GetMyBooks(string userId);

        Task<AddBookViewModel> GetNewAddBookViewModelAsync();

        Task AddBookAsync(AddBookViewModel addBookViewModel);
        Task<BookViewModel?> GetBookByIdAsync(int bookId);

        Task AddBookToCollectionAsync(string userId, BookViewModel book);

        Task RemoveBookFromCollectionAsync(string userId, BookViewModel book);
    }
}
