using Library.Services;
using Library.ViewModels;

namespace Library.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class BookController : BaseController
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            this._bookService = bookService;
        }

        public async Task<IActionResult> All()
        {
            var books = await _bookService.GetAllBooksAsync();

            return View(books);
        }

        public async Task<IActionResult> Mine()
        {
            var userId = GetUserId();

            var books = await _bookService.GetMyBooks(userId);

            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddBookViewModel addBookViewModel = await _bookService.GetNewAddBookViewModelAsync();

            return View(addBookViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel addBookViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addBookViewModel);
            }

            await _bookService.AddBookAsync(addBookViewModel);

            return RedirectToAction("All");
        }

        public async Task<IActionResult> AddToCollection(int id)
        {
            int bookId = id;

            var book = await _bookService.GetBookByIdAsync(bookId);

            if (book == null)
            {
                return BadRequest("tolkoz mnogo noshti i pak ne si go doizpipal");
            }

            var userId = GetUserId();

            await _bookService.AddBookToCollectionAsync(userId, book);

            return RedirectToAction("All");
        }

        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            int bookId = id;

            var book = await _bookService.GetBookByIdAsync(bookId);

            if (book == null)
            {
                return BadRequest("failed to remove from collection");
            }

            var userId = GetUserId();

            await _bookService.RemoveBookFromCollectionAsync(userId, book);

            return RedirectToAction("Mine");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            int bookId = id;

            AddBookViewModel? bookViewModel = await _bookService.GetBookByIdForEditAsync(bookId);

            if (bookViewModel == null)
            {
                return RedirectToAction("All");
            }

            return View(bookViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddBookViewModel bookViewModel)
        {
            int bookId = id;

            if (!ModelState.IsValid)
            {
                return View(bookViewModel);
            }

            await _bookService.EditBookAsync(bookId, bookViewModel);

            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            int bookId = id;

            BookViewModel? bookViewModel = await _bookService.GetBookByIdAsync(bookId);

            if (bookViewModel == null)
            {
                return BadRequest("failed to delete");
            }

            await _bookService.DeleteBookAsync(bookViewModel);

            return RedirectToAction("All");
        }

    }
}