using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task AddBookToCollectionAsync(string userId, BookViewModel book);

        Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync();

        Task<BookViewModel?> GetBookByIdAsync(int id);

        Task<IEnumerable<AllBookViewModel>> GetMyBooksAsync(string userId);

        Task RemoveBookByIdAsync(string id, BookViewModel book);

        Task<ICollection<CategoryViewModel>> GetCategories();

        Task AddBooksPost(AddPostBookViewModel book);
    }
}
